    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual("result", await viewModel.GetString());
        }
    }
