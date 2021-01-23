    public class FooModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Foo model;
            try
            {
                model = (Foo)base.BindModel(controllerContext, bindingContext);
            }
            catch (HttpRequestValidationException)
            {
                // handle here
            }
        }
    }
