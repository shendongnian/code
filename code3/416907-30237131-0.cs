	protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
	{
		if (propertyDescriptor.PropertyType.IsEnum && propertyDescriptor.PropertyType.GetCustomAttributes(typeof(FlagsAttribute), false).Any())
		{
			var value = bindingContext.ValueProvider.GetValue(propertyDescriptor.Name);
			if (value != null)
			{
				// Get type of value.
				var rawValues = value.RawValue as string[];
				if (rawValues != null)
				{
					// Create instance of result object.
					var result = (Enum)Activator.CreateInstance(propertyDescriptor.PropertyType);
					try
					{
						// Try parse enum
						result = (Enum)Enum.Parse(propertyDescriptor.PropertyType, string.Join(",", rawValues));
						// Override property with flags value
						propertyDescriptor.SetValue(bindingContext.Model, result);
						return;
					}
					catch
					{								
					}
				}
			}
			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
		}
		else
			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
	}
