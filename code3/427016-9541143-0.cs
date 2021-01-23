    public class UtcModelBinder : DefaultModelBinder
    {
      protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
      {
        HttpRequestBase request = controllerContext.HttpContext.Request;
        // Detect if this is a JSON request
        if (request.IsAjaxRequest() &&
          request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
        {
          // See if the value is a DateTime
          if (value is DateTime)
          {
            // This is double casting, but since it's a value type there's not much other things we can do
            DateTime dateValue = (DateTime)value;
            if (dateValue.Kind == DateTimeKind.Local)
            {
              // Change it
              DateTime utcDate = dateValue.ToUniversalTime();
              if (!propertyDescriptor.IsReadOnly && propertyDescriptor.PropertyType == typeof(DateTime))
                propertyDescriptor.SetValue(bindingContext.Model, utcDate);
              return;
            }
          }
        }
        // Fall back to the default behavior
        base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
      }
    }
