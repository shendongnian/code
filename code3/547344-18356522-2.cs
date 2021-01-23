    public class InvariantCultureDecimalModelBinder : IModelBinder, IPropertyBinder
    	{
    		public void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
    		{
    			var subPropertyName = CreateSubPropertyName(bindingContext.ModelName, propertyDescriptor.Name);
    			if (!bindingContext.ValueProvider.ContainsPrefix(subPropertyName))
    				return;
    
    			var attemptedValue = bindingContext.ValueProvider.GetValue(subPropertyName).AttemptedValue;
    			if (String.IsNullOrEmpty(attemptedValue))
    				return;
    
    			object actualValue = null;
    			try
    			{
    				actualValue = Convert.ToDecimal(attemptedValue, CultureInfo.InvariantCulture);
    			}
    			catch (FormatException e)
    			{
    				bindingContext.ModelState[propertyDescriptor.Name].Errors.Add(e);
    			}
    
    			propertyDescriptor.SetValue(bindingContext.Model, actualValue);
    		}
    
    		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    		{
    			var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    			var modelState = new ModelState { Value = valueResult };
    			object actualValue = null;
    			try
    			{
    				if (!String.IsNullOrEmpty(valueResult.AttemptedValue))
    					actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.InvariantCulture);
    			}
    			catch (FormatException e)
    			{
    				modelState.Errors.Add(e);
    			}
    
    			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
    			return actualValue;
    		}
    
    		//Duplicate code exits in DefaulModelBinder but it is protected internal
    		private string CreateSubPropertyName(string prefix, string propertyName)
    		{
    			if (string.IsNullOrEmpty(prefix))
    				return propertyName;
    			if (string.IsNullOrEmpty(propertyName))
    				return prefix;
    			else
    				return prefix + "." + propertyName;
    		}
    
    	}
