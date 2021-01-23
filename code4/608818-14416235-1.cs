    namespace NonStorableTest
    {
        //public class Invalid
        //{
        //    public TypedReference i;
        //}
    
        class Program
        {
            static void Main(string[] args)
            {
                AssemblyBuilder asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("EmitNonStorable"),
                                                                                           AssemblyBuilderAccess.RunAndSave);
    
                ModuleBuilder moduleBuilder = asmBuilder.DefineDynamicModule("EmitNonStorable", "EmitNonStorable.dll");
    
                TypeBuilder invalidBuilder = moduleBuilder.DefineType("EmitNonStorable.Invalid",
                                                                      TypeAttributes.Class | TypeAttributes.Public);
    
                ConstructorBuilder constructorBuilder = invalidBuilder.DefineDefaultConstructor(MethodAttributes.Public);
    
                FieldBuilder fieldI = invalidBuilder.DefineField("i", typeof (TypedReference), FieldAttributes.Public);
    
                invalidBuilder.CreateType();
                asmBuilder.Save("EmitNonStorable.dll");
    
                Console.ReadLine();
            }
        }
    }
