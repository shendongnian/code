    var addMethod = typeBuilder.DefineMethod("add_{EventName}",
        MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.SpecialName | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
        CallingConventions.Standard | CallingConventions.HasThis,
        typeof(void),
        new[] { typeof({EventType}) });
    var generator = addMethod.GetILGenerator();
    var combine = typeof(Delegate).GetMethod("Combine", new[] { typeof(Delegate), typeof(Delegate) });
    generator.Emit(OpCodes.Ldarg_0);
    generator.Emit(OpCodes.Ldarg_0);
    generator.Emit(OpCodes.Ldfld, field);
    generator.Emit(OpCodes.Ldarg_1);
    generator.Emit(OpCodes.Call, combine);
    generator.Emit(OpCodes.Castclass, typeof({EventType}));
    generator.Emit(OpCodes.Stfld, field);
    generator.Emit(OpCodes.Ret);
    eventInfo.SetAddOnMethod(addMethod);
    var removeMethod = typeBuilder.DefineMethod("remove_{EventName}",
        MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.SpecialName | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
        CallingConventions.Standard | CallingConventions.HasThis,
        typeof(void),
        new[] { typeof({EventType}) });
    var remove = typeof(Delegate).GetMethod("Remove", new[] { typeof(Delegate), typeof(Delegate) });
    var generator = removeMethod.GetILGenerator();
    generator.Emit(OpCodes.Ldarg_0);
    generator.Emit(OpCodes.Ldarg_0);
    generator.Emit(OpCodes.Ldfld, field);
    generator.Emit(OpCodes.Ldarg_1);
    generator.Emit(OpCodes.Call, remove);
    generator.Emit(OpCodes.Castclass, typeof(PropertyChangedEventHandler));
    generator.Emit(OpCodes.Stfld, field);
    generator.Emit(OpCodes.Ret);
    eventInfo.SetRemoveOnMethod(removeMethod);
