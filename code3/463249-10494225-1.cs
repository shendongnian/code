    public class HttpWebClientWrapperMockCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var mock = new Mock<IHttpWebClientWrapper>();
            mock.Setup(m => m.GetResponse()).Returns(httpResponseMock.Object);
            fixture.Inject(mock);
        }
    }
    public class HttpWebResponseWrapperMockCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var mock = new Mock<IHttpWebResponseWrapper>();
            mock.Setup(m => m.StatusCode).Returns(HttpStatusCode.OK);
            fixture.Inject(mock);
        }
    }
    // The rest of the Customizations.
