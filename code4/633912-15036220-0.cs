    public class EmptyParameterBinding : HttpParameterBinding
    {
        public EmptyParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
        }
        public override bool WillReadBody
        {
            get
            {
                return false;
            }
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
