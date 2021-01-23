    public class CommaDelimitedArrayParameterBinder : HttpParameterBinding, IValueProviderParameterBinding
    {
        public CommaDelimitedArrayParameterBinder(HttpParameterDescriptor desc)
            : base(desc)
        {
        }
        /// <summary>
        /// Handles Binding (Converts a comma delimited string into an array of integers)
        /// </summary>
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                                                 HttpActionContext actionContext,
                                                 CancellationToken cancellationToken)
        {
            var queryString = actionContext.ControllerContext.RouteData.Values[Descriptor.ParameterName] as string;
            var ints = queryString?.Split(',').Select(int.Parse).ToArray();
            SetValue(actionContext, ints);
            return Task.CompletedTask;
        }
        public IEnumerable<ValueProviderFactory> ValueProviderFactories { get; } = new[] { new QueryStringValueProviderFactory() };
    }
