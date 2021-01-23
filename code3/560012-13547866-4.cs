    public class Foo
    {
        private string _name;
        public Foo(string name)
        {
            _name = name;
        }
        public void AnyMethod()
        {
            Console.WriteLine("{0} Called: AnyMethod()", _name);
        }
        public void AnySetValue(string value)
        {
            Console.WriteLine("{0} Called: AnySetValue(string) with {1}", _name, value);
        }
        public string AnySetString(string value)
        {
            Console.WriteLine("{0} Called: AnySetString(string) with {1}", _name, value);
            return value;
        }
    }
