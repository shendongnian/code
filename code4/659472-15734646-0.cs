    public class A
    {
        public virtual void B()
        {
            Console.WriteLine("Original method was called.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create simple assembly to hold our proxy
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "DynamicORMapper";
            AppDomain thisDomain = Thread.GetDomain();
            var asmBuilder = thisDomain.DefineDynamicAssembly(assemblyName,
                         AssemblyBuilderAccess.Run);
            var modBuilder = asmBuilder.DefineDynamicModule(
                         asmBuilder.GetName().Name, false);
           
            // Create a proxy type
            TypeBuilder typeBuilder = modBuilder.DefineType("ProxyA",
               TypeAttributes.Public |
               TypeAttributes.Class |
               TypeAttributes.AutoClass |
               TypeAttributes.AnsiClass |
               TypeAttributes.BeforeFieldInit |
               TypeAttributes.AutoLayout,
               typeof(A));
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("B", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.ReuseSlot);
            typeBuilder.DefineMethodOverride(methodBuilder, typeof(A).GetMethod("B"));
            
            // Generate a Console.Writeline() and base.B() calls.
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitWriteLine("We caught an invoke! B method was called.");
            ilGenerator.EmitCall(OpCodes.Call, typeBuilder.BaseType.GetMethod("B"), new Type[0]);
            ilGenerator.Emit(OpCodes.Ret);
            
            //Create a type and casting it to A. 
            Type type = typeBuilder.CreateType();
            A a = (A) Activator.CreateInstance(type);
           
            // Test it
            a.B();
            Console.ReadLine();
        }
    }
