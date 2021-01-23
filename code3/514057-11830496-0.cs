    public interface IValidator
    {
        void Validate(object value);
    }
    public class ValidationEmailAttribute : Attribute, IValidator
    {
        public Validate(string emailAddress)
        {
            // throw exception or whatever if invalid
        }
    }
    
    public class ValidateParametersAspect : OnMethodBoundaryAspect
    {
        public override OnEntry(args)
        {
            foreach(i = 0 to args.Method.GetParameters().Count)
            {
                var parameter = args.Method.GetParameters()[i];
                var argument = args.Argument[i]; // get the corresponding argument value
                foreach(attribute in parameter.Attributes)
                {
                    var attributeInstance = Activator.CreateType(attribute.Type);
                    var validator = (IValidator)attributeInstance;
                    validator.Validate(argument);
                }
            }
         }
    }
    
    public class MyClass
    {
        [ValidateParametersAspect]
        public void SaveEmail([ValidationEmail] string email)
        {
            // ...
        }
    }
