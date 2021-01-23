    protected override System.ComponentModel.PropertyDescriptorCollection GetModelProperties(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        Type realType = bindingContext.Model.GetType();
        return new AssociatedMetadataTypeTypeDescriptionProvider(realType).GetTypeDescriptor(realType).GetProperties();
    }
    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
            {
                ValueProviderResult result;
                result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".ControlType");
    
                if (result == null)
                    return null;
    
                if (result.AttemptedValue.Equals("TextBox"))
                    return base.CreateModel(controllerContext,
                            bindingContext,
                            typeof(TextBox));
                else if (result.AttemptedValue.Equals("Combo"))
                    return base.CreateModel(controllerContext,
                            bindingContext,
                            typeof(Combo));
                return null;
            }
