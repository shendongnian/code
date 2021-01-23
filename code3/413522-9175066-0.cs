    public class Service {
        private int Step1() {
            return 1;
        }
    }
    
    [TestClass]
    public class TransparentObjectTests {
        [TestMethod]
        public void PrivateMethod() {
            dynamic s = new Service().AsTransparentObject();
            Assert.AreEqual(1, s.Step1());
        }
    }
