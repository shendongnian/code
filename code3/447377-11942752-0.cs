    public class DecimalModelBinder : DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            dynamic valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == null) {
                return base.BindModel(controllerContext, bindingContext);
            }
            return ((string)valueProviderResult.AttemptedValue).TryCDec();
        }
    }
