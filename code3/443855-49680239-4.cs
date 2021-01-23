    public class CustomBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
    
            if (context.Metadata.ModelType == typeof(int[]) || context.Metadata.ModelType == typeof(List<int>))
            {
                return new BinderTypeModelBinder(typeof(CommaDelimitedArrayParameterBinder));
            }
    
            return null;
        }
    }
    
