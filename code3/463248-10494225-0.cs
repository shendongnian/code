    public class HttpMocksCustomization : CompositeCustomization
    {
        public HttpMocksCustomization()
            : base(
                new AutoMoqCustomization(),
                new HttpWebClientWrapperMockCustomization(),
                new HttpWebResponseWrapperMockCustomization()
                // ...
                )
        {
        }
    }
