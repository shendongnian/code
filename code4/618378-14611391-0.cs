    /// <summary>
    /// Configuration Helper for Fluent Security. See http://www.fluentsecurity.net
    /// </summary>
    public static class SecurityConfig
    {
        public static void Configure()
        {
            SecurityConfigurator.Configure(c =>
            {
                c.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);
                c.GetRolesFrom(() => (HttpContext.Current.Session["Roles"] as string[]));
               
                // Blanket Deny All
                c.ForAllControllers().DenyAnonymousAccess();                
                
                // Publicly Available Controllers
                c.For<HomeController>().Ignore();
                c.For<RegistrationsController>().Ignore();
                c.For<LoginController>().Ignore();
                // Only allow Admin To Create
                c.For<ReservationsController>(x => x.Create())
                 .RequireRole(UserRoles.Admin.ToString());
                c.For<ReservationsController>(x => x.Edit(""))
                 .RequireRole(UserRoles.Admin.ToString(),UserRoles.User.ToString());
                c.For<ReservationsController>(x => x.Delete(""))
                 .RequireRole(UserRoles.Admin.ToString(),UserRoles.User.ToString());           
            });
        }
    }
