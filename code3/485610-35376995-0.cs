    public class TestBinder: DefaultModelBinder
    {
    	public override object BindModel(
    			ControllerContext controllerContext,
    			ModelBindingContext bindingContext)
    	{
    		Debug.WriteLine(bindingContext.ModelName);
    		Debug.WriteLine(bindingContext.ModelType.ToString());
    
    		//HOW TO USE: Look at your Output for the most recently output ModelName and Type to determine where there problem lies
    
    		return base.BindModel(controllerContext, bindingContext);
    	}
    }
