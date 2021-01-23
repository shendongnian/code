     // this is not actual mass transit source code
     public class BusCreator
     {
         public static IBus Initialize(Action<IConfiguration> action)
         {
             // create the config instance here
             IConfiguration config = CreateDefaultConfig();
             
             // let callers modify it
             action(config);
 
             // use the final version to build the result
             return config.Build()
         }
     }
