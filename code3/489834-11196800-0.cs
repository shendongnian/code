    public class MyClassModelBinder : DefaultModelBinder
    {
       public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
       {
          var model = new MyClass();
          // ... build the class
          // Store the model inside the HttpContext so that it is accessible later
          controllerContext.HttpContext.Items["model"] = model;
          return model;
        }
    }
