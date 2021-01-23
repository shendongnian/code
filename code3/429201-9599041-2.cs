     public class ConfigurationFactory {
         public static ConfigurationBase GetConfig(Object[] parameters)
               // Build your objects here according to your params... do stuff...
               if (params[0] ...)
                    return New Config2(...)
               elseif ...
                    return New Config1(...)
         }
     }
