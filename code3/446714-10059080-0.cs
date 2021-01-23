    public class YearClassBinder : DefaultModelBinder
    {
        //public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //}
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var model = (Year)base.CreateModel(controllerContext, bindingContext, modelType);
            // ...you change, inspect set etc.
            return model;
        }
    }
