        public class HuggiesModelBinder:DefaultModelBinder
        {
            protected override void BindProperty( ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor )
            {
                if (propertyDescriptor.PropertyType == typeof(DateTime))
                {
                    base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
                }
                // bind the rest of the properties here
            }
        }
