	var ctor = type.GetConstructor(Type.EmptyTypes);
	if (ctor == null) throw new MissingMethodException("There is no constructor without defined parameters for this object");
	DynamicMethod dynamic = new DynamicMethod(string.Empty,
				type,
				Type.EmptyTypes,
				type);
	ILGenerator il = dynamic.GetILGenerator();
	il.DeclareLocal(type);
	il.Emit(OpCodes.Newobj, ctor);
	il.Emit(OpCodes.Stloc_0);
	il.Emit(OpCodes.Ldloc_0);
	il.Emit(OpCodes.Ret);
	var func = (Func<object>)dynamic.CreateDelegate(typeof(Func<object>));
