        var a = new A();
        a.Name = "Name";
        Console.WriteLine(a.Name.GetType().Name);
        PropertyInfo pi = a.GetType().GetProperty("Name");          
        DynamicMethod method = new DynamicMethod(
                "DynamicSetValue", // NAME
                null, // return type
                new Type[] 
                            {
                                typeof(Object), // 0, objSource
                                pi.PropertyType, // 1, value
                            }, // parameter types
                typeof(OracleUserOlapRepositoryTests), // owner
                true); // skip visibility
        ILGenerator gen = method.GetILGenerator();
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldarg_1);
        gen.Emit(OpCodes.Call, pi.GetSetMethod(true));
        gen.Emit(OpCodes.Ret);
       //correct  
       method.Invoke(a, new object[]{a,"test"});
       //error  
       method.Invoke(a, new object[]{a,new List<String>()});
       Console.WriteLine(a.Name.GetType().Name);
