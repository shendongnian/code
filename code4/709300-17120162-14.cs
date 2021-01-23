    class DynamicClass
    {
        public TypeBuilder Builder { get; set; }
        public DynamicClass()
        { 
            var name = new AssemblyName("DynamicAssembly");
            var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("DynamicModule");
            Builder = module.DefineType("DynamicClass", TypeAttributes.Public);
        }
    }
