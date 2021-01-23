    public class CustomServiceRunner<T> : ServiceRunner<T> {
        public CustomServiceRunner(IAppHost appHost, ActionContext actionContext) : base(appHost, actionContext) { }
        //1.
        public override void BeforeEachRequest(IRequestContext requestContext, T request) {
            var validator = AppHost.TryResolve<IValidator<T>>();
            if (validator != null) {
                var result = validator.Validate(request);
                if (!result.IsValid) throw result.ToException();
            }
            base.BeforeEachRequest(requestContext, request);
        }
        //2.
        public override object AfterEachRequest(IRequestContext requestContext, T request, object response) {
            IValidator validator = null;
            if(response.GetType()==typeof(CustomersResponse)) validator= AppHost.TryResolve<IValidator<CustomersResponse>>();
            else if(response.GetType()==typeof(OrdersResponse)) validator= AppHost.TryResolve<IValidator<OrdersResponse>>();
            else if(response.GetType()==typeof(LoginResponse)) validator= AppHost.TryResolve<IValidator<LoginResponse>>();
            //......
            // and 100+ more 'ELSE IF' statements o_O ??
            //......
            if (validator != null) {
                var result = validator.Validate(response);
                if (!result.IsValid) throw result.ToException();
            }
            return base.AfterEachRequest(requestContext, request, response);
        }
    
    }
