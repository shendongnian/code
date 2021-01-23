    public static LateBoundPropertySet CreateSet(PropertyInfo property)
    {
        var method = new DynamicMethod("Set" + property.Name, null, new[] { typeof(object), typeof(object) }, true);
        var gen = method.GetILGenerator();
    
        var sourceType = property.DeclaringType;
        var setter = property.GetSetMethod(true);
    
        gen.Emit(OpCodes.Ldarg_0); // Load input to stack
        gen.Emit(OpCodes.Castclass, sourceType); // Cast to source type
        gen.Emit(OpCodes.Ldarg_1); // Load value to stack
        gen.Emit(OpCodes.Unbox_Any, property.PropertyType); // Unbox the value to its proper value type
        gen.Emit(OpCodes.Callvirt, setter); // Call the setter method
        gen.Emit(OpCodes.Ret);
    
        var result = (LateBoundPropertySet)method.CreateDelegate(typeof(LateBoundPropertySet));
    
        return result;
    }
