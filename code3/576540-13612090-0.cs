    private static void Main(string[] args) {
        // change 'yournamespace'
        Type testType = Type.GetType("yournamespace.MyClass`1");
        Type[] testTypeGenericArgs = testType.GetGenericArguments();
        
        // Get T type from MyClass generic args
        Type tType = testTypeGenericArgs[0];
        Type genericListType = Type.GetType("System.Collections.Generic.List`1");
        // create type List<T>
        Type openListType = genericListType.MakeGenericType(testTypeGenericArgs[0]);
        Type genericTuple = Type.GetType("System.Tuple`2");
        Type stringType = Type.GetType("System.String");
        // create type Tuple<T, string>
        Type openTuple = genericTuple.MakeGenericType(new[] { tType, stringType });
        // create type List<Tuple<T, string>>
        Type openListOfTuple = genericListType.MakeGenericType(openTuple);
        Type[] typesFromStrings = new[] { tType, openListType, openListOfTuple };
        // get method parameters per example
        Type myClassType = typeof(MyClass<>);
        MethodInfo myMethodInfo = myClassType.GetMethod("MyMethod");
        Type[] paramTypes = myMethodInfo.GetParameters().Select(pi => pi.ParameterType).ToArray();
        
        // compare type created from strings against types
        // retrieved by reflection
        for (int i = 0; i < typesFromStrings.Length; i++) {
            Console.WriteLine(typesFromStrings[i].Equals(paramTypes[i]));
        }
        Console.ReadLine();
    }
