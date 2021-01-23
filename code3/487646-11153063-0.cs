    protected internal void UpdateModelUsingQueryString<TModel>(TModel model) where TModel : class
    {
        if (model == null) throw new ArgumentNullException("model");
        Predicate<string> propertyFilter = propertyName => new BindAttribute().IsPropertyAllowed(propertyName);
        var binder = Binders.GetBinder(typeof(TModel));
        var bindingContext = new ModelBindingContext()
        {
            ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType()),
            ModelState = ModelState,
            PropertyFilter = propertyFilter,
            ValueProvider = new QueryStringValueProvider(ControllerContext)
        };
        binder.BindModel(ControllerContext, bindingContext);
    }
