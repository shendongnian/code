    public class TransferFundsPresenterTest
    {
        private Mockery mocks;
        private IMyProxyServer mockProxyServer
        
        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockProxyServer = mocks.NewMock<IMyProxyServer>();
        }
        [Test]
        public void TestProxyFunction()
        {
            Expect.Once.On(mockProxyServer).
                Method("ProxyFunctionA").
                With("1234").   //  <-- simulate the input params here
                Will(Return.Value("Test"));  // <-- simulate the output from server here
        }
