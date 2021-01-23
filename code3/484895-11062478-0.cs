    public class MyRouteManager : IRoutesManager
    { 
        bool ImportRoute(Stream inputStream, string fileName)
        { code here etc etc } 
        List<Route> GetAllRoutes();
        List<Route> GetAllRoutesForDate(DateTime from, DateTime to);
        void DeleteRoute(string routeName);
        void DeleteAllRoutes();
    }
