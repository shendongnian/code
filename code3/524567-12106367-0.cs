     public static void RegisterGlobalFilters(GlobalFilterCollection filters)
     {
            filters.Add(new HandleErrorAttribute());
            // Add global filters via DI.
            new SimpleInjectorGlobalFilters(filters);
     }
