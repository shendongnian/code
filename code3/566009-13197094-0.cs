    class Options
    {
        [TypeConversionValidator(typeof(bool), MessageTemplate = "IsRed value must be a true/false")]
        public dynamic IsRed { get; set; }
        [TypeConversionValidator(typeof(bool), MessageTemplate = "IsBlue value must be a true/false")]
        public dynamic IsBlue { get; set; }
    }
        private ValidationResults LoadOptions()
        {
            _options.IsRed = ConfigurationManager.AppSettings["IsRed"];
            _options.IsBlue = ConfigurationManager.AppSettings["IsBlue"];
            var valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            var cusValidator = valFactory.CreateValidator<Options>();
            var optionValidator = cusValidator.Validate(_options);
            if (optionValidator.IsValid)
            {
                _options.IsBlue = Convert.ToBoolean(_options.IsBlue);
                _options.IsRed = Convert.ToBoolean(_options.IsRed);
            }
            return optionValidator;
        }
