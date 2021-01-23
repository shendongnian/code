    public class MyPrincipal : IPrincipal 
    {
        public MyPrincipal(MyIdentity identity)
        {
            Identity = identity;
            
        }
        public MyIdentity Identity {get; private set; }
        IIdentity IPrincipal.Identity { get { return this.Identity; } }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
