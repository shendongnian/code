    public class SomeClass
        {
            private IWebServiceProxy proxy;
            public SomeClass(IWebServiceProxy proxy)
            {
                this.proxy = proxy;
            }
            public void PostTheProduct()
            {
                proxy.Post("/MyService/Product");
            }
            public void REstGetCall()
            {
                proxy.Get("/MyService/Product/{productId}");
            }
        }
