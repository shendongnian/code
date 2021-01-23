    public class MyPrincipal : IPrincipal 
    {
        public MyPrincipal(MyIdentity identity)
        {
            Identity = identity;
        }
        public MyIdentity Identity {get; private set; }
        IPrincipal.IIdentity {get {return this.Identity; } }
        ...
    }
