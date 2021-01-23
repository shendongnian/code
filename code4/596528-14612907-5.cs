    public static class SecurityConfig
        {
            public static void Configure()
            {
                SecurityConfigurator.Configure(c =>
                    {
                        c.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);
                        c.GetRolesFrom(() => (HttpContext.Current.Session["Roles"] as string[]));
                            // Blanked Deny All
                        c.ForAllControllers().DenyAnonymousAccess();
                                
                        // Publicly Accessible Areas
                        c.For<LoginController>().Ignore();
    
                        // This is the part for finding all of the classes that inherit
                        // from IPolicyViolationHandler so you don't have to use an IOC
                        // Container.
                        c.ResolveServicesUsing(type =>
                            {
                                if (type == typeof (IPolicyViolationHandler))
                                {
                                    var types = Assembly
                                        .GetAssembly(typeof(MvcApplication))
                                        .GetTypes()
                                        .Where(x => typeof(IPolicyViolationHandler).IsAssignableFrom(x)).ToList();
    
                                    var handlers = types.Select(t => Activator.CreateInstance(t) as IPolicyViolationHandler).ToList();
    
                                    return handlers;
                                }
                                return Enumerable.Empty<object>();
                            });
                    });
            }
        }
