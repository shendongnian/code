    public class UniqueEmailAddress : ValidationAttribute
    {
        private IEmployeeRepository _employeeRepository;
        [Inject]
        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository; }
            set
            {
                _employeeRepository = value;
            }
        }
        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {
            var model = (EmployeeModel)validationContext.ObjectInstance;
            if(model.Field1 == null){
                return new ValidationResult("Field1 is null");
            }
            if(model.Field2 == null){
                return new ValidationResult("Field2 is null");
            }
            if(model.Field3 == null){
                return new ValidationResult("Field3 is null");
            }
            return ValidationResult.Success;
        }
    }
    
