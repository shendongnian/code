        public CustomValidatorClass(string template, string tag)
            : base(template, tag)
        {
            
        }
        protected override string DefaultMessageTemplate
        {
            get { return "blah blah"; }
        }
        public override void DoValidate(object objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            //Do something here
        }
    }
