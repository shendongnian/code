    public class CachedModelBinder : DefaultModelBinder {
    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
        if (cachedModel != null)
            return cachedModel;
        return base.BindModel(controllerContext, bindingContext);
        }
    }
