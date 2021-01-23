    public class XDocumentModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            if (!request.ContentType.StartsWith("text/xml", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            return XDocument.Load(request.InputStream);
        }
    }
