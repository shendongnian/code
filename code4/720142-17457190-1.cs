    public class AuthenticationInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            bool authenticated = // ... get the current user ...
            if (authenticated)
                invocation.Proceed();
            else
                RedirectToLoginPage(); // however you want to do this
        }
    }
    public class RequiresAuthenticationAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Context.Kernel.Get<AuthenticationInterceptor>();
        }
    }
    [RequiresAuthentication]
    public class OrdersController : IOrdersController
    {
        // assume you've already been authenticated
    }
