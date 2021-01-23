    public class ConfigurationFactory {
    	public ConfigurationBase GetConfig(object[] parameters)
    	   // Build your objects here according to your params... do stuff...
    	   if (parameters[0] ...)
    			return new Config2(...);
    	   elseif ...
    			return new Config1(...);
    	}
    }
