    public class TestClass
    {
        [TestValidation]
        public string TestProp { get; set; }
    }
    public class TestValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return new TestResult();
        }
    }
    public class TestResult : ValidationResult
    {
        public TestResult()
            : base("test")
        {
        }
    }
