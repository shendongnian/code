    public class CustomModelBinder : IModelBinder
    {
      public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
      {
        string inputContent;
        using (var sr = new StreamReader(controllerContext.HttpContext.Request.InputStream))
        {
          inputContent = sr.ReadToEnd();
        }
        //JsonConvert is part of Json.NET
        var result = JsonConvert.DeserializeObject(inputContent, bindingContext.ModelType);
        return result;
      }
    }
