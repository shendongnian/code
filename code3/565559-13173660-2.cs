    [TestFixture]
    public class GoldCardTests
    {
        [Test]
        // balance, year, expected result
        [TestCase(2400, 0, 72)]
        [TestCase(2500, 0, 72)] // you did not define a rule for this case
        [TestCase(2600, 1, 104)] 
        // add more test cases so all rules are defined
        public void CalcCouponValue_should_calculate_correctly(double balance, double year, double expectedResult)
        {
             // arrange your test (sut == system under test)
             var sut = new GoldCard(null, null, balance, year);
             // act (execute the test)
             var actualResult = sut.CalcCouponValue();
             // assert (verify that what you get is what you want)
             Assert.That(actualResult, Is.EqualTo(expectedResult));             
        }
    }
