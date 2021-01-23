    public class UniqueUsername : ValidationAttribute
    {
        public override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success; // In Edit view you can't edit username so it's null
            var currentUser = validationContext.ObjectInstance as User;
            FinanceDataContext _db = new FinanceDataContext();
            var user = _db.Users.ToList().Where(x => x.Username.ToLower() == value.ToString().ToLower() && x.ID != currentUser.ID).SingleOrDefault();
    
            if (user == null) return ValidationResult.Success;
            return new ValidationResult("Username exists");
        }
    }
