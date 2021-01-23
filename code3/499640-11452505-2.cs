    TInterface GenerateInterfaceImplementation<TInterface>(
        params object[] methods)
    {
        var interfaceType = typeof(TInterface);
        AssemblyName aName = new AssemblyName(
            "Dynamic" + interfaceType.Name + "WrapperAssembly");
        var assBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
            aName,
            AssemblyBuilderAccess.Run);
        var modBuilder = assBuilder.DefineDynamicModule(aName.Name);
        TypeBuilder typeBuilder = modBuilder.DefineType(
            "Dynamic" + interfaceType.Name + "Wrapper",
             TypeAttributes.Public);
        // Define a constructor taknig the same parameters as this method.
        var ctrBuilder = typeBuilder.DefineConstructor(
            MethodAttributes.Public | MethodAttributes.HideBySig |
                MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
            CallingConventions.Standard,
            methods.Select(o => o.GetType()).ToArray());
        // Start building the constructor.
        var ctrGenerator = ctrBuilder.GetILGenerator();
        ctrGenerator.Emit(OpCodes.Ldarg_0);
        ctrGenerator.Emit(
            OpCodes.Call,
            typeof(object).GetConstructor(Type.EmptyTypes));
        // For each interface method, we add a field to hold the supplied
        // delegate, code to store it in the constructor, and an
        // implementation that calls the delegate.
        byte methodIndex = 0;
        foreach (var interfaceMethod in interfaceType.GetMethods())
        {
            var delegateField = typeBuilder.DefineField(
                interfaceMethod.Name + "_del",
                methods[methodIndex].GetType(),
                FieldAttributes.Private);
            ctrGenerator.Emit(OpCodes.Ldarg_0);
            ctrGenerator.Emit(OpCodes.Ldarg_S, methodIndex + 1);
            ctrGenerator.Emit(OpCodes.Stfld, delegateField);
            var metBuilder = typeBuilder.DefineMethod(
                interfaceMethod.Name,
                MethodAttributes.Public | MethodAttributes.Virtual |
                    MethodAttributes.Final | MethodAttributes.HideBySig |
                    MethodAttributes.NewSlot,
                interfaceMethod.ReturnType,
                interfaceMethod.GetParameters()
                    .Select(p => p.ParameterType).ToArray());
            var metGenerator = metBuilder.GetILGenerator();
            metGenerator.Emit(OpCodes.Ldarg_0);
            metGenerator.Emit(OpCodes.Ldfld, delegateField);
            // Generate code to load each parameter.
            byte paramIndex = 1;
            foreach (var param in interfaceMethod.GetParameters())
            {
                metGenerator.Emit(OpCodes.Ldarg_S, paramIndex);
                paramIndex++;
            }
            metGenerator.EmitCall(
                OpCodes.Callvirt,
                methods[methodIndex].GetType().GetMethod("Invoke"),
                null);
            metGenerator.Emit(OpCodes.Ret);
            methodIndex++;
        }
        ctrGenerator.Emit(OpCodes.Ret);
        // Add interface implementation and finish creating.
        typeBuilder.AddInterfaceImplementation(interfaceType);
        var wrapperType = typeBuilder.CreateType();
        // Return an instance using the constructor we created.
        return (TInterface)Activator.CreateInstance(wrapperType, methods);
    }
