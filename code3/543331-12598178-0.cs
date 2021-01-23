    public class Validator<T>
    {
        List<Func<T,bool> _validators = new List<Func<T, bool>>();
        public void AddPropertyValidator(Func<T, bool> propValidator) 
        {
            _validators.Add(propValidator);
        }
        public bool IsValid(T objectToValidate)
        {
             try {
             _validators.All(pv => pv(objectToValidate))
             } catch(Exception) {
                return false;
             }
        }
    }
    class ExampleObject {
         public string Name {get; set;}
         public int BirthYear { get;set;}
    }
    public static void Main(string[] args) 
    {
        var validator = new Validator<ExampleObject>();
        validator.AddPropertyValidator(o => !string.IsNullOrEmpty(o.Name));
        validator.AddPropertyValidator(o => o.BirthYear > 1900 && o.BirthYear < DateTime.Now.Year );
        validator.AddPropertyValidator(o => o.Name.Length > 3);
        validator.Validate(new ExampleObject());
    }
