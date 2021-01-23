    public class CustomModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
    
            var propertyMetadata = bindingContext.PropertyMetadata[propertyDescriptor.Name];
            var invalidMessage = propertyMetadata.AdditionalValues.ContainsKey("PropertyValueInvalid")
                                     ? (string)propertyMetadata.AdditionalValues["PropertyValueInvalid"]
                                     : string.Empty;
            if (string.IsNullOrEmpty(invalidMessage))
            {
                return;
            }
    
            // code from DefaultModelBinder
            string fullPropertyKey = CreateSubPropertyName(bindingContext.ModelName, propertyDescriptor.Name);
            if (!bindingContext.ValueProvider.ContainsPrefix(fullPropertyKey))
            {
                return;
            }
            ModelState modelState = bindingContext.ModelState[fullPropertyKey];
            foreach (ModelError error in modelState.Errors.Where(err => String.IsNullOrEmpty(err.ErrorMessage) && err.Exception != null).ToList())
            {
                for (Exception exception = error.Exception; exception != null; exception = exception.InnerException)
                {
                    if (exception is FormatException)
                    {
                        string displayName = propertyMetadata.GetDisplayName();
                        string errorMessageTemplate = invalidMessage;
                        string errorMessage = String.Format(CultureInfo.CurrentCulture, errorMessageTemplate,
                                                            modelState.Value.AttemptedValue, displayName);
                        modelState.Errors.Remove(error);
                        modelState.Errors.Add(errorMessage);
                        break;
                    }
                }
            }
        }
    }
