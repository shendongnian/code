    public static class CityRepository
    {
       private static bool areCitiesLoaded;
       private List<City> cities;
       static CityRepository()
       {
         areCitiesLoaded = false;
         cities = new List<City>();
       }
       //method that will be called in all other method, to ensure
       //that the cities are loaded
       private static void EnsureLoad()
       {
          if (!areCitiesLoaded)
          {
            LoadAllCitiesFromDatabase();
            areCitiesLoaded = true;
          }
       }
    }
    public class City {} //city instance methods
