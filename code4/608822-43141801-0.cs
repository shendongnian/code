    public sealed class ReflectionUtils
        {
            public static T ObjectInitializer<T>(Action<T> initialize)
            {
                var result = Activator.CreateInstance<T>();
                initialize(result);
                return result;
            }
        }
    
    public class MyModel
    {
        public string Name{get;set;}
    }
