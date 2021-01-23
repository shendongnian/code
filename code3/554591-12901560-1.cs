    /// <summary>
    /// A custom model binder for boolean values. This behaves the same as the default
    /// one, except it will resolve the value to false if it cannot be parsed.
    /// </summary>
    public class BooleanModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            bool parsed = false;
            if (Boolean.TryParse(valueResult.AttemptedValue, out parsed))
            {
                bindingContext.ModelState.Add(bindingContext.ModelName, new ModelState { Value = valueResult });
                return parsed;
            }
            return false;
        }
    }
    //in Global.asax
    protected void Application_Start()
    {
        ...
        ModelBinders.Binders.Add(typeof(bool), new BooleanModelBinder());
    }
