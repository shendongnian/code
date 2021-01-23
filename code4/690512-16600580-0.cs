    public class IntArrayModelBinder : System.Web.Mvc.DefaultModelBinder
    {
        public override object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!string.IsNullOrEmpty(valueProviderResult.AttemptedValue))
            {
                var items = valueProviderResult.AttemptedValue.Split(',');
                var result = new int[items.Length];
                for (var counter = 0; counter < items.Length; counter++)
                {
                    var intVal = int.Parse(items[counter]);
                }
                return result;
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
