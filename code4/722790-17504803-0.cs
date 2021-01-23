    namespace TestXml
    {
        public class MyClass
        {
            public string Value { get; set; }
            public MyClass(string value)
            {
                Value = value;
            }
    
            public override string ToString()
            {
                return Value;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyClass[] parameter = new MyClass[] { new MyClass("1") };
                execute(() => TestInput( new MyClass[] { new MyClass("1") }));
                execute(() => TestInput(parameter));
            }
    
            public static void TestInput(params object[] parameters)
            {
                if (parameters != null && parameters.Length > 0) Console.WriteLine(parameters.GetType().FullName);
            }
    
            public static void execute(Expression<Action> exp)
            {
                Console.WriteLine(exp);
            }
    
            public delegate void ParamsDelegate(params object[] param);
        }
    }
