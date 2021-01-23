    public class WarningsDataAnnotationsModelValidatorProvider: DataAnnotationsModelValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
          var ignoreWarnings = context.Controller.ValueProvider.GetValue("IgnoreWarnings");
    
          if (ignoreWarnings != null && bool.Parse(ignoreWarnings.AttemptedValue.ToString()))
          {
            // filter the WarningAttributes
            attributes = attributes.Where(a => !a.GetType().IsSubclassOf(typeof(WarningAttribute)));
          }
    
          return base.GetValidators(metadata, context, attributes);
        }
    }
