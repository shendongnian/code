    static void Main(string[] args)
    {
        Person p = new Person();
        p.Age = 4;
            
        var results = Validator.Validate(p);
        results.ToList().ForEach(error => Console.WriteLine(error));
        Console.Read();
    }       
    // Simple Validator class
    public static class Validator
    {
        // This could return a ValidationResult object etc
        public static IEnumerable<string> Validate(object o)
        {
            Type type = o.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Type attrType = typeof (ValidationAttribute);
            foreach (var propertyInfo in properties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    bool isValid = validationAttribute.IsValid(propertyInfo.GetValue(o, BindingFlags.GetProperty, null, null, null));
                    if (!isValid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
    public class Person
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Range(5, 20, ErrorMessage = "Must be between 5 and 20!")]
        public int Age { get; set; }
    }
