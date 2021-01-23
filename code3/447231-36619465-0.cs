    using (var context = new PrincipalContext(ContextType.Domain)) {
      using (var user = UserPrincipal.FindByIdentity(context, userName)) {
        if (user != null) {
           return user.EmailAddress;
        }
      }
    }
