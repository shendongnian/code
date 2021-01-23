        class MyClass<T>
        {
            public void MyMethod(T a, List<T> b, List<Tuple<T, string>> c) { }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                //input.
                var typesAsStr = new string[] { "T", "List`1[T]", "List`1[Tuple`2[T, string]]" };
    
                //type to find a method.
                Type testType = typeof(MyClass<>);
                //possibly iterate through methods instead?
                MethodInfo myMethodInfo = testType.GetMethod("MyMethod");
                //get array of strings describing MyMethod's arguments.
                string[] paramTypes = myMethodInfo.GetParameters().Select(pi => TypeToString(pi.ParameterType)).ToArray();
    
                //compare arrays of strings (can be improved).
                var index = -1;
                Console.WriteLine("Method found: {0}", typesAsStr.All(str => { index++; return index < paramTypes.Length && str == paramTypes[index]; }));
    
                Console.ReadLine();
            }
    
            private static CSharpCodeProvider compiler = new CSharpCodeProvider();
            private static string TypeToString(Type type)
            {
                if (type.IsGenericType) {
                    return type.Name + "[" + string.Join(", ", type.GetGenericArguments().Select(ga => TypeToString(ga))) + "]";
                }
                else if (type.IsGenericParameter) {
                    return type.Name;
                }
    
                //next line gives "string" (lower case for System.String).
                //additional type name translations can be applied if output is not what we neeed.
                return compiler.GetTypeOutput(new CodeTypeReference(type));
            }
        }
