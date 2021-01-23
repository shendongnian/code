    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    namespace ValidationDemo
    {
    class Program
    {
        static void Main(string[] args)
        {
            var ord = new Order();
            // If this isnt present, the validate doesnt get called since the Annotation are INVALID so why check further...
            ord.Code = "SomeValue";   // If this isnt present, the validate doesnt get called since the Annotation are INVALID so why check further...
            var vc = new ValidationContext(ord, null, null);
            var vResults = new List<ValidationResult>();    // teh results are here
            var isValid = Validator.TryValidateObject(ord, vc, vResults, true);    // the true false result
            System.Console.WriteLine(isValid.ToString());
            System.Console.ReadKey();
        }
    }
    public class Order : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public   IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var vResult = new List<ValidationResult>(); 
            if (Code != "FooBar") // the test conditions here
            {
                {
                    var memberList = new List<string> { "Code" }; // The
                    var err = new ValidationResult("Invalid Code", memberList);
                    vResult.Add(err);
                }
            }
            return vResult;
        }
    }
}
