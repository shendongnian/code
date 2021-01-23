    public class MyPrincipal : IPrincipal 
    {
        public MyIdentity Identity {get; private set; }
        IPrincipal.IIdentity {get {return this.Identity; } }
        ...
    }
