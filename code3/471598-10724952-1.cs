      public class CustomModelBinder : DefaultModelBinder
      {
          protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
          {
            if (propertyDescriptor.Name == "HomePhone")
            {
              var form = controllerContext.HttpContext.Request.Form;
        
              var countryCode = form["HomePhone.CountryCode"];
              var areaCode = form["HomePhone.AreaCode"];
              var number = form["HomePhone.Number"];
              if (string.IsNullOrEmpty(countryCode) && string.IsNullOrEmpty(areaCode) && string.IsNullOrEmpty(number))
                return;
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
          }
      }
