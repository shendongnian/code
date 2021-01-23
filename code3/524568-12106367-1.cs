    public class SimpleInjectorGlobalFilters
    {
        public SimpleInjectorGlobalFilters(GlobalFilterCollection filters)
         {
            var container = DependencyResolver.Current;
            filters.Add(container.GetService(typeof(UserAuthorisation)));
        }
    }
