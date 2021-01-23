    [TestFixture]
    public class GoldCardTests
    {
        [TestCase(2000, 1, 2000 * 0.03)]
        [TestCase(2500, 1, 2500 * 0.04)]
        public void TestNameTest(double balance, int year, double expected)
        {
            var goldCard = new GoldCard("", "", balance, year);
            double calcCouponValue = goldCard.CalcCouponValue();
            Assert.AreEqual(expected,calcCouponValue);
        }
    }
    
