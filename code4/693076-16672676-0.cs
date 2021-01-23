    abstract class Bank
    {
        #region fields
        private List<string> errorMessages = new List<string>();
        #endregion
        #region publioc methods
        public virtual void Validate()
        {
            ValidateRulesAtributes();
        }
        #endregion
        #region helper methods
        private void ValidateRulesAtributes()
        {
            var validationContext = new ValidationContext(this, null, null); //ValidationContext -> Reference System.ComponentModel.DataAnnotations
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, result, true);
            result.ForEach(p => { errorMessages.Add(p.ErrorMessage); });
            if (errorMessages.Any())
                throw new Exception(errorMessages.Aggregate((m1, m2) => String.Concat(m1, Environment.NewLine, m2)));
        }
        protected void Validate(List<string> messages)
        {
            if (errorMessages == null)
                errorMessages = new List<string>();
            if (messages != null)
                messages.ForEach(p => { errorMessages.Add(p); });
            ValidateRulesAtributes();
        }
        #endregion
        #region properties
        //Abstract to indicate Validation atributes 
        public abstract string AccountNumber { get; set; }
        public abstract double Amount { get; set; }
        public abstract int InvoicePeriod { get; set; }
        #endregion
    }
