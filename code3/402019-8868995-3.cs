    public class ByteArrayModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var buffer = new byte[request.InputStream.Length];
            request.InputStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
