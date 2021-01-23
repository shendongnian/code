    public class IsLocalAttribute : AuthorizeAttribute
    {
        public bool ThrowSecurityException { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isLocal = httpContext.Request.IsLocal;
            if (ThrowSecurityException)
                throw new SecurityException();
            return isLocal;
        }
    }
