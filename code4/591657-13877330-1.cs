    public virtual bool CallValidation(string ruleSet)
    		{
    			Errors = new List<ValidationFailure>();
    			ValidatorAttribute val = this.GetType().GetCustomAttributes(typeof(ValidatorAttribute), true)[0] as ValidatorAttribute;
    			IValidator validator = Activator.CreateInstance(val.ValidatorType) as IValidator;
    			FluentValidation.Results.ValidationResult result = validator.Validate(new FluentValidation.ValidationContext(this, new PropertyChain(), new RulesetValidatorSelector(ruleSet)));
    			FluentValidation.Results.ValidationResult resultCommon = validator.Validate(this);
    			IsValid = (result.IsValid && resultCommon.IsValid);
    			Errors = result.Errors.Union(resultCommon.Errors).ToList();
    			return IsValid;
    		}
