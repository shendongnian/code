    namespace ValidApp.App_Code
    {
        public class _Validators : BaseValidator
        {   
            protected override bool EvaluateIsValid()
            {
                string value = this.GetControlValidationValue(ControlToValidate);
                return Regex.IsMatch(value, @"^[a-z0-9]{6-8}$");
            }
    
            public _Validators()
            {
                       
            }
        }
    }
