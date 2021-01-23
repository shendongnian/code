    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass<int>();
            // Closed type
            var closedType = obj.GetType();
            // Open generic (typeof(MyClass<>))
            var openType = closedType.GetGenericTypeDefinition();
            // Methods on open type
            var fooT = openType.GetMethod("Foo");
            var barint = openType.GetMethod("Bar");
            // Parameter types
            var tInFoo = fooT.GetParameters()[0].ParameterType;
            var iInBar = barint.GetParameters()[0].ParameterType;
            // Are they generic?
            var tInFooIsGeneric = tInFoo.ContainsGenericParameters;
            var iInBarIsGeneric = iInBar.ContainsGenericParameters;
            Console.WriteLine(tInFooIsGeneric);
            Console.WriteLine(iInBarIsGeneric);
            Console.ReadKey();
        }
    }
