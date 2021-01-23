     //  around application start, configure the way values are retrieved   
     //  from names for different types.  Note that this doesn't need to use
     //  a NameValueCollection, but I did so to stay consistent.
     var collection = new NameValueCollection();
     ValueRegistry.Configure<int>(name => GetInt32(collection,name));
     ValueRegistry.Configure<DateTime>(name => GetDateTime(collection,name));
     // where you are going to need to get values
     var values = new ValueRegistry();      
     int value = values.Get<int>("the name"); // nothing is boxed
    public class ValueRegistry
    {
           private class Provider<T> 
                where T : struct
           {
                 private static readonly ConcurrentDictionary<ValueRegistry,Provider<T>> Providers = new ConcurrentDictionary<ValueRegistry,Provider<T>>();
                  public static Provider<T> For(ValueRegistry registry)
                  {
                      return Providers.GetOrAdd(registry, x => new Provider<T>());
                  }
                  private Provider(){
                     this.entries = new Dictionary<string,T>();
                  }
                  private readonly Dictionary<string,T> entries;
                  private static Func<string,T> CustomGetter;
                  public static void Configure(Func<string,T> getter) { CustomGetter = getter;}
                  
                  public static T GetValueOrDefault(string name)
                  {
                       T value;
                        if(!entries.TryGetValue(name, out value))
                           entries[name] = value = CustomGetter != null ? CustomGetter(name) : default(T);
                         return value;
                  }
           }
          
           public T Get<T>(string name) 
              where T : struct
           {
               return Provider<T>.For(this).GetValueOrDefault(name);
           }
           public static void Configure<T>(Func<string,T> customGetter)
                      where T : struct
           {
              Provider<T>.Configure(customGetter);      
           }
           
    }
