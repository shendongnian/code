    public class TesteModelBinder2 : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
        {
              NameValueCollection values = controllerContext.HttpContext.Request.Form;
              if (propertyDescriptor.PropertyType.Equals(typeof(ShortStrOra)))
              {
                  ShortStrOra value = new ShortStrOra(values[propertyDescriptor.Name]);
                  propertyDescriptor.SetValue(bindingContext.Model, value);
                  return;
              }
              else 
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
