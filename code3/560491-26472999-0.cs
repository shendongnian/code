    public class DelegatingHandlerProxy<TDelegatingHandler> : DelegatingHandler
        where TDelegatingHandler : DelegatingHandler
    {
        private readonly WindsorContainer container;
        public DelegatingHandlerProxy(WindsorContainer container)
        {
            this.container = container;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // trigger the creation of the scope.
            request.GetDependencyScope();
            var handler = this.container.Resolve<TDelegatingHandler>();
            handler.InnerHandler = this.InnerHandler;
            var invoker = new HttpMessageInvoker(handler);
    
            var response = await invoker.SendAsync(request, cancellationToken);
            container.Release(handler);
            return response;
        }
    }
