    public class DynamicModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.Request.Form.AllKeys.Any(x => x == "dynamic"))
            {
                dynamic model = new ExpandoObject();
                IDictionary<string, object> underlyingmodel = model;
    
                foreach (var key in controllerContext.HttpContext.Request.Form.AllKeys)
                    underlyingmodel.Add(key, (bindingContext.ValueProvider.GetValue(key).RawValue as string[]).First());
    
                return model;
            }
    
            return base.BindModel(controllerContext, bindingContext);
        }
    }
