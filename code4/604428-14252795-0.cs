    /// <summary>
    /// Pushes the specified member onto the evaluation stack.
    /// </summary>
    /// <param name="generator">The generator.</param>
    /// <param name="member">The member.</param>
    public static void EmitLoadMemberInfo(this ILGenerator generator, MemberInfo member)
    {
        switch (member.MemberType)
        {
            case MemberTypes.Method:
                generator.Emit(OpCodes.Ldtoken, member as MethodInfo);
                generator.Emit(OpCodes.Call, typeof(MethodBase).GetMethod("GetMethodFromHandle", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(RuntimeMethodHandle) }, null));
                break;
            case MemberTypes.TypeInfo:
                generator.Emit(OpCodes.Ldtoken, member as Type);
                generator.Emit(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle", BindingFlags.Public | BindingFlags.Static));
                break;
            case MemberTypes.Field:
                generator.Emit(OpCodes.Ldtoken, member as FieldInfo);
                generator.Emit(OpCodes.Call, typeof(FieldInfo).GetMethod("GetFieldFromHandle", BindingFlags.Public | BindingFlags.Static));
                break;
            case MemberTypes.Constructor:
				generator.Emit(OpCodes.Ldtoken, member as ConstructorInfo);
                generator.Emit(OpCodes.Call, typeof(MethodBase).GetMethod("GetMethodFromHandle", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(RuntimeMethodHandle) }, null));
                break;
				
            default:
                throw new NotSupportedException("Unsupported token type.");
        }
    }
