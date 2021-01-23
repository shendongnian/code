    public class XDocumentModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return XDocument.Load(controllerContext.HttpContext.Request.InputStream);
        }
    }
