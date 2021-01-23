    // Get handle to the method that is going to be called.
    MethodInfo executeMethod = typeof(Services).GetMethod("Execute");
    // Create assembly, module and a type (class) in it.
    AssemblyName assemblyName = new AssemblyName("MyAssembly");
    AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run, (IEnumerable<CustomAttributeBuilder>)null);
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule");
    TypeBuilder typeBuilder = moduleBuilder.DefineType("MyClass", TypeAttributes.Class | TypeAttributes.Public, typeof(object), new Type[] { typeof(IMyService) });
    typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
    // Implement each interface method.
    foreach (MethodInfo method in typeof(IMyService).GetMethods())
    {
        ServiceImportAttribute attr = method
            .GetCustomAttributes(typeof(ServiceImportAttribute), false)
            .Cast<ServiceImportAttribute>()
            .SingleOrDefault();
        var parameters = method.GetParameters();
        if (attr == null)
        {
            throw new ArgumentException(string.Format("Method {0} on interface IMyService does not define ServiceImport attribute."));
        }
        else
        {
            // There is ServiceImport attribute defined on the method.
            // Implement the method.
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                method.Name,
                MethodAttributes.Public | MethodAttributes.Virtual,
                CallingConventions.HasThis,
                method.ReturnType,
                parameters.Select(p => p.ParameterType).ToArray());
            // Generate the method body.
            ILGenerator methodGenerator = methodBuilder.GetILGenerator();
            LocalBuilder paramsLocal = methodGenerator.DeclareLocal(typeof(object[])); // Create the local variable for the params array.
            methodGenerator.Emit(OpCodes.Ldc_I4, parameters.Length); // Amount of elements in the params array.
            methodGenerator.Emit(OpCodes.Newarr, typeof(object)); // Create the new array.
            methodGenerator.Emit(OpCodes.Stloc, paramsLocal); // Store the array in the local variable.
            // Copy method parameters to the params array.
            for (int i = 0; i < parameters.Length; i++)
            {
                methodGenerator.Emit(OpCodes.Ldloc, paramsLocal); // Load the params local variable.
                methodGenerator.Emit(OpCodes.Ldc_I4, i); // Value will be saved in the index i.
                methodGenerator.Emit(OpCodes.Ldarg, (short)(i + 1)); // Load value of the (i + 1) parameter. Note that parameter with index 0 is skipped, because it is "this".
                if (parameters[i].ParameterType.IsValueType)
                {
                    methodGenerator.Emit(OpCodes.Box, parameters[i].ParameterType); // If the parameter is of value type, it needs to be boxed, otherwise it cannot be put into object[] array.
                }
                methodGenerator.Emit(OpCodes.Stelem, typeof(object)); // Set element in the array.
            }
            // Call the method.
            methodGenerator.Emit(OpCodes.Ldstr, attr.Name); // Load name of the service to execute.
            methodGenerator.Emit(OpCodes.Ldloc, paramsLocal); // Load the params array.
            methodGenerator.Emit(OpCodes.Call, executeMethod); // Invoke the "Execute" method.
            methodGenerator.Emit(OpCodes.Ret); // Return the returned value.
        }
    }
    Type generatedType = typeBuilder.CreateType();
    
    // Create an instance of the type and test it.
    IMyService service = (IMyService)generatedType.GetConstructor(new Type[] { }).Invoke(new object[] { });
    service.ServiceName(1, "aaa");
