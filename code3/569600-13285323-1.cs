        void Main()
    {
    	var x = GetConstructorInfo(typeof(SomeClass));
    	
    	x.Dump();
    	x.IsStatic.Dump();
    }
    
    
    public class PreferredConstructorAttribute : Attribute{
    
    }
    public class SomeClass{
      private static int staticField = 10;
    
    }
    
    private ConstructorInfo GetConstructorInfo(Type serviceType)
    		{
    			Type resolveTo = serviceType;
    
    			
    //#if NETFX_CORE
    			var constructorInfos = resolveTo.GetTypeInfo().DeclaredConstructors.ToArray();
    			constructorInfos.Dump();
    //#else
    //			var constructorInfos = resolveTo.GetConstructors();
    //constructorInfos.Dump();
    //#endif
    
    			if (constructorInfos.Length > 1)
    			{
    				var preferredConstructorInfos
    					= from t in constructorInfos
    //#if NETFX_CORE
    					   let attribute = t.GetCustomAttribute(typeof (PreferredConstructorAttribute))
    //#else
    //					   let attribute = Attribute.GetCustomAttribute(t, typeof(PreferredConstructorAttribute))
    //#endif
    					   where attribute != null
    					   select t;
    
    preferredConstructorInfos.Dump();
    
    var preferredConstructorInfo = preferredConstructorInfos.FirstOrDefault ( );
    				if (preferredConstructorInfo == null)
    				{
    					throw new InvalidOperationException(
    						"Cannot build instance: Multiple constructors found but none marked with PreferredConstructor.");
    				}
    
    				return preferredConstructorInfo;
    			}
    
    			return constructorInfos[0];
    		}
    // Define other methods and classes here
