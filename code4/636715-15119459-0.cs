    public class CachedModelBinder : DefaultModelBinder {
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
        if (cachedModel != null)
            return cachedModel;
        return base.BindModel(controllerContext, bindingContext);
    }
