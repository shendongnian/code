    public class CustomFileModelBinder : ByteArrayModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var file = controllerContext.HttpContext.Request.Files[bindingContext.ModelName];
     
            if (file != null)
            {
                if (file.ContentLength != 0 && !String.IsNullOrEmpty(file.FileName))
                {
                    var fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, fileBytes.Length);
                    return fileBytes;
                }
     
                return null;
            }
     
            return base.BindModel(controllerContext, bindingContext);
        }
    }
    protected void Application_Start()
    {
        ...
        ModelBinders.Binders.Remove(typeof(byte[]));
        ModelBinders.Binders.Add(typeof(byte[]), new CustomFileModelBinder());
    }
