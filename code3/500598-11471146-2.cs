    public class MyUser : GenericPrincipal
    {
        public MyUser(IIdentity identity, string[] roles)
            : base(identity, roles)
        {
    
        }
    
        public Guid Id { get; set; }
    }
