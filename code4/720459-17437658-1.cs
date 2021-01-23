    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                if (valueResult.AttemptedValue.StartsWith("$"))
                {
                    actualValue = decimal.Parse(valueResult.AttemptedValue, NumberStyles.Currency);
                }
                if (valueResult.AttemptedValue.EndsWith("%"))
                {
                    actualValue = decimal.Parse(valueResult.AttemptedValue.Replace("%", "").Trim(),
                                                CultureInfo.CurrentCulture);
                }
                if (actualValue == null)
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue,
                                                    CultureInfo.CurrentCulture);
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
