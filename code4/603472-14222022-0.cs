    [TestClass]
    public class TestControllersHomeController
    {
        private HomeController _sut;
        [TestInitialize]
        public void MyTestInitialize() 
        {
            var kernel = NinjectWebCommon.CreatePublicKernel();
            _sut = kernel.Resolve<HomeController>();
        }
        [TestMethod]
        public void TestIndex()
        {
            var result = _sut.Index();
            Assert.IsNotNull(result);
        }
    }
