    public class TypedJsonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var json = (string) bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ConvertTo(typeof (string));
                return JsonConvert.DeserializeObject(json, bindingContext.ModelType);
            }
            catch
            {
                return null;
            }
        }
    }
