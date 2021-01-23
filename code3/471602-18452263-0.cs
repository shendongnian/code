    protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
         {
             if (!propertyDescriptor.Attributes.OfType<RequiredAttribute>().Any())
             {
                 var form = controllerContext.HttpContext.Request.Form;
                 if (form.AllKeys.Where(k => k.StartsWith(string.Format(propertyDescriptor.Name, "."))).Count() > 0)
                 {
                     if (form.AllKeys.Where(k => k.StartsWith(string.Format(propertyDescriptor.Name, "."))).All(
                             k => string.IsNullOrWhiteSpace(form[k])))
                         return;
                 }
             }
             base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
         }
