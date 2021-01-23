    public class IntegerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            int temp;
            var attemptedValue = value != null ? value.AttemptedValue : string.Empty;
            if (!int.TryParse(attemptedValue, out temp)
            )
            {
                var errorMessage = "{0} is an invalid integer";
                if (bindingContext.ModelMetadata.AdditionalValues.ContainsKey("errorMessage"))
                {
                    errorMessage = bindingContext.ModelMetadata.AdditionalValues["errorMessage"] as string;
                }
                errorMessage = string.Format(errorMessage, attemptedValue);
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, errorMessage);
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                return null;
            }
            return temp;
        }
    }
