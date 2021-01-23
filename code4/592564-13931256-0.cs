    public class IdentityNumberAttribute : ValidationAttribute
    {
        private string WrongIdentityNumber;
        public IdentityNumberAttribute(string message)
        {
            WrongIdentityNumber = message;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string identityNumber = value.ToString();
            if (identityNumber.Length != 11)
                return new ValidationResult(WrongIdentityNumber);
            int sum = 0;
            for (int i = 0; i < identityNumber.Length - 1; i++)
            {
                sum += Convert.ToInt32(identityNumber[i].ToString());
            }
            return sum.ToString()[1] == identityNumber[10]
                       ? ValidationResult.Success
                       : new ValidationResult(WrongIdentityNumber);
        }
    }
