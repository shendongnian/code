    // almost pseudocode !!
    // called by /api/City/123?extended=true
    public City Get(int id, bool? extended)
    {
       ExtendedCity city = GetCity(id);
       return extended.HasValue && extended.Value ? MapTo(city) : city;
    }
    
    // ----
    
    public class City
    {
       ...
    }
    
    public class ExtendedCity : City
    {
       ...
    }
