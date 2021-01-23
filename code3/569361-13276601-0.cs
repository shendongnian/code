            AssemblyName asn = new AssemblyName("test.dll");
            AssemblyBuilder asb = AppDomain.CurrentDomain.DefineDynamicAssembly(
                asn, AssemblyBuilderAccess.RunAndSave, @"D:\test_assemblies");
            ModuleBuilder modb = asb.DefineDynamicModule("test", "test.dll");
            TypeBuilder tb = modb.DefineType(
                "test",
                TypeAttributes.Public | TypeAttributes.Class);
            // Typebuilder is a sub class of Type
            tb.SetParent(typeof(OtherClass<>).MakeGenericType(tb));
            var t2 = tb.CreateType();
            var i = Activator.CreateInstance(t2);
