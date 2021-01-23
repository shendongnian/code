    public class NullableDoubleModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            if (valueResult.AttemptedValue != null)
            {
                try
                {
                    actualValue = Convert.ToDouble(valueResult.AttemptedValue, CultureInfo.InvariantCulture);
                }
                catch (FormatException e)
                {
                    modelState.Errors.Add(e);
                }
            }
    
    
    
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
