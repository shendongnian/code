    public class MyModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            /// MyBaseClass and MyDerievedClass are hardcoded.
            /// We can use reflection to read the assembly and get concrete types of any base type
            if (modelType.Equals(typeof(MyBaseClass)))
            {
                Type instantiationType = typeof(MyDerievedClass);                
                var obj=Activator.CreateInstance(instantiationType);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, instantiationType);
                bindingContext.ModelMetadata.Model = obj;
                return obj;
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    
    }
