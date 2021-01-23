        public class WebAPIValidationFactory : ModelValidatorProvider
    {
        private readonly MVCValidationFactory _mvcValidationFactory;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public WebAPIValidationFactory(MVCValidationFactory mvcValidationFactory)
        {
            _mvcValidationFactory = mvcValidationFactory;
        }
        public override IEnumerable<ModelValidator> GetValidators(
            ModelMetadata metadata, IEnumerable<ModelValidatorProvider> validatorProviders)
        {
            try
            {
                var type = GetType(metadata);
                if (type != null)
                {
                    var fluentValidator =
                        _mvcValidationFactory.CreateInstance(typeof(FluentValidation.IValidator<>).MakeGenericType(type));
                    if (fluentValidator != null)
                    {
                        return new List<ModelValidator>
                                   {
                                       new FluentValidationModelValidator(
                                           validatorProviders, fluentValidator)
                                   };
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return new List<ModelValidator>();
        }
        private static Type GetType(ModelMetadata metadata)
        {
            Type type = metadata.ContainerType != null ? metadata.ContainerType.UnderlyingSystemType : null;
            return type;
        }
