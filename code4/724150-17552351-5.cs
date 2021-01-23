    var locator = new NinjectServiceLocator(kernel);
    ServiceLocator.SetLocatorProvider(() => locator);
    SecurityConfigurator.Configure(
                configuration =>
                {
                    configuration.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);
                    configuration.GetRolesFrom(SecurityHelpers.UserRoles);
                    //HomeController and other configurations
                    configuration.For<HomeController>().Ignore();
                    configuration.ResolveServicesUsing(ServiceLocator.Current.GetAllInstances);
                 }
                 );
    GlobalFilters.Filters.Add(new HandleSecurityAttribute(), 0);
