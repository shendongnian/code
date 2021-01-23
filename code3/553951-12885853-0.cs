    [TestClass]
    public class Parking
    {
        private int GetParkingCharge(int minutesParked)
        {
            return (int)Math.Ceiling(minutesParked/30f);
        }
        [TestMethod]
        public void TestParking()
        {
            Assert.AreEqual(0, GetParkingCharge(0));
            Assert.AreEqual(1, GetParkingCharge(25));
            Assert.AreEqual(2, GetParkingCharge(45));
            Assert.AreEqual(2, GetParkingCharge(60));
            Assert.AreEqual(3, GetParkingCharge(61));
            Assert.AreEqual(3, GetParkingCharge(90));
            Assert.AreEqual(4, GetParkingCharge(91));
        }
    }
