    // You'll need this
    public interface ISquareRootHelper
    {
        double Sqrt<T>(T value)
            where T : struct;
    }
    class Program
    {
        private static ISquareRootHelper helper; 
        
        // Build the helper
        public static void BuildSqrtHelper()
        {
            // Let's use a guid for the assembly name, because guid!
            var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
            // Blah, blah, boiler-plate dynamicXXX stuff
            var dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var dynamicModule = dynamicAssembly.DefineDynamicModule(assemblyName.Name);
            var dynamicType = dynamicModule.DefineType("SquareRootHelper");
            // Let's create our generic square root method in our dynamic type
            var sqrtMethod = dynamicType.DefineMethod("Sqrt", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual);
            sqrtMethod.SetReturnType(typeof(double));
            // Well, I guess here is where we actually make the method generic
            var genericParam = sqrtMethod.DefineGenericParameters(new[] {"T"});
            genericParam[0].SetGenericParameterAttributes(GenericParameterAttributes.NotNullableValueTypeConstraint);
            // Add a generic parameter, and set it to override our interface method
            sqrtMethod.SetParameters(genericParam);
            dynamicType.DefineMethodOverride(sqrtMethod, typeof(ISquareRootHelper).GetMethod("Sqrt"));
            // Magic sauce!
            var ilGenerator = sqrtMethod.GetILGenerator();
            // Math.Sqrt((double)value);
            ilGenerator.Emit(OpCodes.Ldarg_1); // arg_0 is this*
            ilGenerator.Emit(OpCodes.Conv_R8);
            var mathSqrtMethodInfo = typeof(Math).GetMethod("Sqrt");
            ilGenerator.EmitCall(OpCodes.Call, mathSqrtMethodInfo, null);
            ilGenerator.Emit(OpCodes.Ret);
            // Since we're overriding the interface method, we need to have the type
            // implement the interface
            dynamicType.AddInterfaceImplementation(typeof(ISquareRootHelper));
            // Create an instance of the class
            var sqrtHelperType = dynamicType.CreateType();
            helper = (ISquareRootHelper)Activator.CreateInstance(sqrtHelperType);
        }
        public static void Main(string[] args)
        {
            BuildSqrtHelper();
            Console.WriteLine(helper.Sqrt((short)64));    // Works!
            Console.WriteLine(helper.Sqrt((ushort)64));   // Works!
            Console.WriteLine(helper.Sqrt((int)64));      // Works!
            Console.WriteLine(helper.Sqrt((uint)64));     // Works*!
            Console.WriteLine(helper.Sqrt((byte)64));     // Works!
            Console.WriteLine(helper.Sqrt((sbyte)64));    // Works!
            Console.WriteLine(helper.Sqrt((float)64));    // Works!
            Console.WriteLine(helper.Sqrt((double)64));   // Works!
            Console.WriteLine(helper.Sqrt((long)64));     // Works!
            Console.WriteLine(helper.Sqrt((ulong)64));    // Works*!
            // Let's try non-primitives!
            Console.WriteLine(helper.Sqrt(DateTime.Now)); // Doesn't fail, but doesn't actually work
            Console.WriteLine(helper.Sqrt(Guid.NewGuid())); // InvalidProgramException!
        }
    }
