     public class ByIdTypedFactoryComponentSelector : DefaultTypedFactoryComponentSelector
     {
    	  protected override string GetComponentName(MethodInfo method, object[] arguments)
    	  {
    			if (method.Name == "GetById" && arguments.Length > 0 && arguments[0] is YourEnum)
    			{
    				 return (string)arguments[0].ToString();
    			}
    
    			return base.GetComponentName(method, arguments);
    	  }
    }
