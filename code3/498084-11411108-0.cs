    var dictionaryBindingContext = new ModelBindingContext()
                {
                    ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => null, typeof(IDictionary<long, int>)),
                    ModelName = "dataFromView", //The name(s) of the form elements you want going into the dictionary
                    ModelState = bindingContext.ModelState,
                    PropertyFilter = bindingContext.PropertyFilter,
                    ValueProvider = bindingContext.ValueProvider
                };
    
    var boundValues = base.BindModel(controllerContext, dictionaryBindingContext);
