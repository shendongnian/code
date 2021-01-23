        public static Type CreateNewType(string assemblyName, string typeName, params Type[] types)
        {
            // Let's start by creating a new assembly
            AssemblyName dynamicAssemblyName = new AssemblyName(assemblyName);
            AssemblyBuilder dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(dynamicAssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder dynamicModule = dynamicAssembly.DefineDynamicModule(assemblyName);
            // Now let's build a new type
            TypeBuilder dynamicAnonymousType = dynamicModule.DefineType(typeName, TypeAttributes.Public);
            // Let's add some fields to the type.
            int itemNo = 1;
            foreach (Type type in types)
            {
                dynamicAnonymousType.DefineField("Item" + itemNo++, type, FieldAttributes.Public);
            }
            // Return the type to the caller
            return dynamicAnonymousType.CreateType();
        }
