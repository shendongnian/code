    // Create instance of Dictionaty<,>
    generator.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
    // Store instance in local variable "target"
    generator.Emit(OpCodes.Stloc, target);
    // Load first method argument to the stack (for static method - argument, for non-static - instance for with method called)
    generator.Emit(OpCodes.Ldarg_0);
    // Store argument in local variable "source"
    generator.Emit(OpCodes.Stloc, source);
    // Load value of local variable "source" to the stack
    generator.Emit(OpCodes.Ldloc, source);
    // Call method GetEnumerator of type IEnumerable<> 
    generator.Emit(OpCodes.Callvirt, type.GetMethod("GetEnumerator"));
    // Store value returned from method in local variable "enumerator"
    generator.Emit(OpCodes.Stloc, enumerator);
