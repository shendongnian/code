    class User : IUser {
      private System.Security.Principal.WindowsIdentity identity;
      public User() {
        this.identity = identity = System.Security.Principal.WindowsIdentity.GetCurrent();
      }
      public string UserName { get { return this.identity.Name; } }
    }
