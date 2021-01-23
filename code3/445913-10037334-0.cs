    public class OAuthProviderClassBinder : DefaultModelBinder
    {
        //public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //}
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var model = (OAuthProvider)base.CreateModel(controllerContext, bindingContext, modelType);
            // ...you change, inspect set etc.
            return model;
        }
    }
