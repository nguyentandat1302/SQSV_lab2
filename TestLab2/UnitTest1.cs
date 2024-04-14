using SQSV_lab2;
using FluentAssertions;

namespace TestLab2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            float income = 100000000; // Thu nhập cao
            float dependentQty = 2;    
            float expectedResult = 0.035F * (income - TaxCalculator.MONTHLY_REDUNDANT - dependentQty * TaxCalculator.DEPENDENT_REDUNDANT) - 9850000;

           
            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            
            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForNoDependent_ShouldBeCorrect()
        {
            // Arrange
            float income = 20000000; //  Thu nhập trung bình
            float dependentQty = 0;  
            float expectedResult = 0.02F * (income - TaxCalculator.MONTHLY_REDUNDANT - dependentQty * TaxCalculator.DEPENDENT_REDUNDANT) - 3250000;

            // Act
            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            // Assert
            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForMultipleDependents_ShouldBeCorrect()
        {
            // Arrange
            float income = 50000000; // Thu nhập trung bình cao
            float dependentQty = 3;  
            float expectedResult = 0.02F * (income - TaxCalculator.MONTHLY_REDUNDANT - dependentQty * TaxCalculator.DEPENDENT_REDUNDANT) - 3250000;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForZeroIncome_ShouldBeZero()
        {
            float income = 0;
            float dependentQty = 1;
            float expectedResult = 0;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForIncomeFromZeroToFiveMillion_ShouldBeCorrect()
        {
            // Arrange
            float income = 3000000;
            float dependentQty = 1;
            float expectedResult = 0.005F * income;

            // Act
            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            // Assert
            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }


        [TestMethod]
        public void Calculate_TaxForIncomeFromFiveMillionToTenMillion_ShouldBeCorrect()
        {
            // Arrange
            float income = 8000000;
            float dependentQty = 1;
            float expectedResult = 0.01F * income - 250000;

            // Act
            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            // Assert
            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForIncomeAboveEightyMillion_ShouldBeCorrect()
        {
            // Arrange
            float income = 90000000;
            float dependentQty = 1;
            float expectedResult = 0.035F * income - 9850000;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

    }
}