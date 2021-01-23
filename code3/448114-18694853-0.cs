    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        return !string.IsNullOrWhiteSpace(result.AttemptedValue) ? ObjectId.Parse(result.AttemptedValue) : ObjectId.Empty;
    }
