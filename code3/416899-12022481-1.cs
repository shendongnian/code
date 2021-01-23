            // Fetch value to bind.
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                // Get type of value.
                Type valueType = bindingContext.ModelType;
                var rawValues = value.RawValue as string[];
                if (rawValues != null)
                {
                    // Create instance of result object.
                    var result = (Enum)Activator.CreateInstance(valueType);
                    try
                    {
                        // Parse.
                        result = (Enum)Enum.Parse(valueType, string.Join(",", rawValues));
                        return result;
                    }
                    catch
                    {
                        return base.BindModel(controllerContext, bindingContext);
                    }
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
