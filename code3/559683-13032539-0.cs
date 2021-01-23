    public class Cache
    {
       private Dictionary<string, object> CachedValues;
    
       public object this [string arg]
       {
           get
           {
               return CachedValues[arg];
           }
       }
    }
