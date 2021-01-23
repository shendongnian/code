    namespace MyProject.<whatever>
    {
      public static IPrincipalExtensions
      {
        public bool IsAdminOrDomainAC(this IPrincipal instance, string name)
        {
          if (instance == null
            || instance.Identity == null
            || !instance.Identity.IsAuthenticated)
          {
            return false;
          }
          return instance.IsInRole(@"Admin")
            || instance.Identity.Name == name;
        }
      }
    }
