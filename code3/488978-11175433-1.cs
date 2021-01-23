    public class DashFormValueProviderFactory : ValueProviderFactory
    {
    	public override IValueProvider GetValueProvider(ControllerContext controllerContext)
    	{
    		if (controllerContext == null)
    		{
    			throw new ArgumentNullException("controllerContext");
    		}
    
    		return new DashFormValueProvider(controllerContext);
    	}
    }
