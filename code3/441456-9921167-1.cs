    public class IntegerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            int temp;
            if (value == null || 
                string.IsNullOrEmpty(value.AttemptedValue) || 
                !int.TryParse(value.AttemptedValue, out temp)
            )
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "invalid integer");
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                return null;
            }
            return temp;
        }
    }
