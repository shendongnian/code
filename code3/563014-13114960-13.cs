        public class BaseModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                // call to get the BaseModel data so we can access the Type property
                var obj = base.BindModel(controllerContext, bindingContext);
                var bm = obj as BaseModel;
                if(bm != null)
                {
                    //call base.BindModel again but this time with a new 
                    // binding context based on the spefiic model type
                    obj = base.BindModel(
                        controllerContext,
                        new ModelBindingContext(bindingContext)
                            {
                                ModelMetadata =
                                    ModelMetadataProviders.Current.GetMetadataForType(null, Type.GetType(bm.Type)),
                                    ModelName = bindingContext.ModelName
                            });
                }
                return obj;
            }
        }
  
