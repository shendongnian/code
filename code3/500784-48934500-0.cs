    public class NullModelBinder : DefaultModelBinder
    {
    	public bool PropertyWasSet { get; set; }
    
    	public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    	{
    		object model = base.BindModel(controllerContext, bindingContext);
    		if (!PropertyWasSet)
    		{
    			return null;
    		}
    
    		return model;
    	}
    
    	protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
    	{
    		base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
    		PropertyWasSet = true;
    	}
    }
