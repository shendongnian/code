        //...continuation of CompareStrings class
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[] { new ModelClientValidationCompareStringsRule(FormatErrorMessage(metadata.GetDisplayName()), OtherPropertyName, IgnoreCase) };
        }
    }
