    public class MyCustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            foreach (var propertyInfo in typeof(bindingContext.Model.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
               if (propertyInfo.PropertyType == typeof(string)) 
               {
                   var value = propertyInfo.GetValue(bindingContext.Model);
                   // validate
                   // append to ModelState if validation failed
                   bindingContext.ModelState.AddModelError(propertyInfo.Name, "Validation Failed");
               }
            }
        }
    }
