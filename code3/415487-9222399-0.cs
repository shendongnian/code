    public class StringTrimmingBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // trim your string here and act accordingly
            // in the case the model property isn't a string
            return base.BindModel(controllerContext, bindingContext);
        }
    }
