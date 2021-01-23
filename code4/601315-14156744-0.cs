    class DynamicTest : DynamicObject
    {
        public DynamicTest(string xyz)
        {
            _xyz = xyz;
        }
        private string _xyz;
        public static implicit operator bool(DynamicTest rhs)
        {
            return rhs._xyz != null;
        }
        public static implicit operator string(DynamicTest rhs)
        {
            return rhs._xyz;
        }
        //TODO: what to override to get required behaviour
    }
    class Program
    {
        static void Main(string[] args)
        {
            dynamic foo = new DynamicTest("test");
            if (foo)  // treat foo as boolean
            { // jump in here when _xyz of foo has a value
                System.Console.WriteLine((string)foo); //treat foo as string   //Importat: (string)foo to go operatorstring 
            }
            else
            { // jump in here when _xyz of foo is null
                System.Console.WriteLine("No Value In Object");
            }
        }
    }
