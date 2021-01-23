    he configuration for these providers is the same as the existing SqlMembershipProvider class, but the type parameter is set to the type of the new providers, as shown in the following table:
    
    SQL Provider Types	-> Equivalent Type for Universal Providers
    System.Web.Security.SqlMembershipProvider ->	System.Web.Providers.DefaultMembershipProvider
    System.Web.Profile.SqlProfileProvider ->	System.Web.Providers.DefaultProfileProvider
    System.Web.Security.SqlRoleProvider ->	System.Web.Providers.DefaultRoleProvider
    (Built in provider)	System.Web.Providers.DefaultSessionStateProvider
