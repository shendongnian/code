    public class AuthenticatedPrincipal : IPrincipal
    {
        private readonly IPrincipal _principalToWrap;
        private readonly IIdentity _identityToWrap;
        public AuthenticatedPrincipal(IPrincipal principalToWrap)
        {
            _principalToWrap = principalToWrap;
            _identityToWrap = new AuthenticatedIdentity(principalToWrap.Identity);
        }
        public bool IsInRole(string role)
        { return _principalToWrap.IsInRole(role); }
        public IIdentity Identity
        {
            get { return _identityToWrap; }
            private set { throw new NotSupportedException(); }
        }
    }
    public class AuthenticatedIdentity : IIdentity
    {
        private readonly IIdentity _identityToWrap;
        public AuthenticatedIdentity(IIdentity identityToWrap)
        {
            _identityToWrap = identityToWrap;
        }
        public string Name
        {
            get { return _identityToWrap.Name; }
            private set { throw new NotSupportedException(); }
        }
        public string AuthenticationType
        {
            get { return _identityToWrap.AuthenticationType; }
            private set { throw new NotSupportedException(); }
        }
        public bool IsAuthenticated
        {
            get { return true; }
            private set { throw new NotSupportedException(); }
        }
    }
