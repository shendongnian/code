    public class BaseModelBinder : DefaultModelBinder
        {
            protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
            {
                var d = base.CreateModel(controllerContext, bindingContext, modelType);
                var a = d as BaseModel;
                if(a != null)
                {
                    d = base.CreateModel(controllerContext, bindingContext, bindingContext.ModelType);
                }
                return d;
            }
    
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var a = base.BindModel(controllerContext, bindingContext);
                var d = a as BaseModel;
                if(d != null)
                {
                    // bindingContext.ModelType = Type.GetType(d.Type);
                    a = base.BindModel(
                        controllerContext,
                        new ModelBindingContext(bindingContext)
                            {
                                ModelMetadata =
                                    ModelMetadataProviders.Current.GetMetadataForType(null, Type.GetType(d.Type)),
                                    ModelName = bindingContext.ModelName // NOTE: 2nd UPDATE
                            });
                }
                return a;
            }
        }
  
