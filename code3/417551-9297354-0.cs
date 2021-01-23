    public interface IHttpMethod
    {
        MemoryStream ResponseBodyAsStream { get; set; }
    }
    public interface IHttpClient
    {
        void ExecuteMethod(IHttpMethod method);
    }
    public class HttpClient : IHttpClient
    {
        #region IHttpClient Members
        public void ExecuteMethod(IHttpMethod method)
        {
            
        }
        #endregion
    }
    public class Factory
    {
        public virtual IHttpClient CreateHttpClient()
        {
            return new HttpClient();
        }
    }
    public class ClassUnderTest
    {
        private readonly Factory _factory;
        public ClassUnderTest(Factory factory)
        {
            _factory = factory;
        }
        public string GetResponseAsString(IHttpMethod method)
        {
            var myClient = _factory.CreateHttpClient();
            myClient.ExecuteMethod(method);
            return method.ResponseBodyAsStream.ToString();
        }
    }
    [TestClass]
    public class ScratchPadTest
    {
        [TestMethod]
        public void SampleTest()
        {
            var mockHttpMethod = new Mock<IHttpMethod>();
            mockHttpMethod.Setup(x => x.ResponseBodyAsStream).Returns(new MemoryStream(Encoding.UTF8.GetBytes("foo")));
            var modifyHttpMethod = new Action<IHttpMethod>(m =>
            {
                m = mockHttpMethod.Object;
            });
            var mockHttpClient = new Mock<IHttpClient>();
            mockHttpClient.Setup(c => c.ExecuteMethod(It.IsAny<IHttpMethod>())).Callback<IHttpMethod>(modifyHttpMethod);
            var myFactoryStub = new Mock<Factory>();
            myFactoryStub.Setup(f => f.CreateHttpClient()).Returns(mockHttpClient.Object);
            var myCut = new ClassUnderTest(myFactoryStub.Object);
            Assert.IsNotNull(myCut.GetResponseAsString(mockHttpMethod.Object));
        }
    }
