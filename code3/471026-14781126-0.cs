    public class MyAuthorizationFilterFactory : IFilterInstanceFactory
    {
        private readonly IAuthorizationProvider provider;
        public MyAuthorizationFilterFactory(IAuthorizationProvider provider)
        {
            this.provider = provider;
        }
        public object Create(Attribute attribute)
        {
            MyAuthorizeAttribute authorizeAttribute = attribute as MyAuthorizeAttribute;
            if (authorizeAttribute == null)
            {
                return null;
            }
            return new MyAuthorizationFilter(provider, authorizeAttribute.Code);
       }
    }
