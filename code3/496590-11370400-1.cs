    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    {
        var typeValue = bindingContext.ValueProvider.GetValue("UrunType");
        var type = Type.GetType(
            (string)typeValue.ConvertTo(typeof(string)),
            true
        );
        var model = Activator.CreateInstance(type);
        bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
        return model;
    }
