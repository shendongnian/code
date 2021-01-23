	public class MvcRegularExpressionAttributeAdapter : RegularExpressionAttributeAdapter {
		public MvcRegularExpressionAttributeAdapter(ModelMetadata metadata, ControllerContext context, RegularExpressionAttribute attribute)
		  : base(metadata, context, attribute) {
		}
		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
		  return MvcValidationResultsTranslation.TranslateClientValidationRules(base.GetClientValidationRules(), this.Metadata, this.ControllerContext, this.Attribute);
		}
		public override IEnumerable<ModelValidationResult> Validate(object container) {
		  return MvcValidationResultsTranslation.TranslateValidationResults(base.Validate(container), this.Metadata, this.ControllerContext, this.Attribute);
		}
	}
----
	 public class MvcValidationResultsTranslation {
		public static IEnumerable<ModelClientValidationRule> TranslateClientValidationRules(IEnumerable<ModelClientValidationRule> validationRules, ModelMetadata metadata, ControllerContext context, ValidationAttribute validationAttribute) {
		  if (validationRules == null) {
			return validationRules;
		  }
		  MvcController mvcController = context.Controller as MvcController;
		  if (mvcController == null) {
			return validationRules;
		  }
		  if (!string.IsNullOrWhiteSpace(validationAttribute.ErrorMessageResourceName) && validationAttribute.ErrorMessageResourceType != null) {
			// if resource key and resource type is set, do not override..         
			return validationRules;
		  }
		  string translatedText = GetTranslation(metadata, mvcController, validationAttribute);
		  foreach (var validationRule in validationRules) {
			List<string> msgParams = new List<string>();
			msgParams.Add(!string.IsNullOrEmpty(metadata.DisplayName) ? metadata.DisplayName : metadata.PropertyName);
			if (validationRule.ValidationParameters != null) {
			  msgParams.AddRange(validationRule.ValidationParameters.Where(p => p.Value.GetType().IsValueType || p.Value.GetType().IsEnum).Select(p => p.Value.ToString()));
			}
			validationRule.ErrorMessage = string.Format(translatedText, msgParams.ToArray());
		  }
		  return validationRules;
		}    
		public static IEnumerable<ModelValidationResult> TranslateValidationResults(IEnumerable<ModelValidationResult> validationResults, ModelMetadata metadata, ControllerContext context, ValidationAttribute validationAttribute) {
		  if (validationResults == null) {
			return validationResults;
		  }
		  MvcController mvcController = context.Controller as MvcController;
		  if (mvcController == null) {
			return validationResults;
		  }
		  if (!string.IsNullOrWhiteSpace(validationAttribute.ErrorMessageResourceName) && validationAttribute.ErrorMessageResourceType != null) {
			// if resource key and resource type is set, do not override..         
			return validationResults;
		  }
		  string translatedText = GetTranslation(metadata, mvcController, validationAttribute);
		  List<ModelValidationResult> newValidationResults = new List<ModelValidationResult>();
		  foreach (var validationResult in validationResults) {
			ModelValidationResult newValidationResult = new ModelValidationResult();
			newValidationResult.Message = string.Format(translatedText, (!string.IsNullOrEmpty(metadata.DisplayName) ? metadata.DisplayName : metadata.PropertyName));
			newValidationResults.Add(newValidationResult);
		  }
		  return newValidationResults;
		}
	}
