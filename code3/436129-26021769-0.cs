        public class UnitTestHttpMessageInvoker : HttpMessageInvoker
        {
            private readonly HttpConfiguration configuration;
            public UnitTestHttpMessageInvoker(HttpMessageHandler handler, IDependencyResolver resolver)
            : base(handler, true)
            {
                this.configuration = new HttpConfiguration();
                configuration.DependencyResolver = resolver;
            }
            [DebuggerNonUserCode]
            public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request == null)
                {
                    throw new ArgumentNullException("request");
                }
                request.Properties["MS_HttpConfiguration"] = this.configuration;
                return base.SendAsync(request, cancellationToken);
            }
        }
