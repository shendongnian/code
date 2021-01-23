    var locator = new NinjectServiceLocator(kernel);
    ServiceLocator.SetLocatorProvider(() => locator);
    SecurityConfigurator.Configure(
                configuration =>
                {
                    configuration.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);
                    configuration.GetRolesFrom(Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name));
                    //HomeController and other configurations
                    configuration.For<HomeController>().Ignore();
                    configuration.ResolveServicesUsing(ServiceLocator.Current.GetAllInstances);
                 }
                 );
    GlobalFilters.Filters.Add(new HandleSecurityAttribute(), 0);
