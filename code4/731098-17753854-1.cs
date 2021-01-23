    public class DynamicModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private IUnityContainer _context;
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
		{			
            foreach (Attribute attribute in attributes)
                _context.BuildUp(attribute);
            return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
		}
	
        public DynamicModelMetadataProvider(IUnityContainer context)
            : base()
        {
            this._context = context;
        }
    }
