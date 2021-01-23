    partial class User
    {
      private IPrincipal underlayingPrincipal;
      public IIdentity Identity 
      {
        get
        {
            return this.underlayingPrincipal.Identity;
        }
      }
      public User(IPrincipal principal, User user)
      {
        this.underlayingPrincipal = principal;
        this.Id = user.Id;
        this.Name = user.Name;
        this.Role = user.Role;
      }
      public bool IsInRole(string role)
      {
        return this.Role == role;
      }
    }
