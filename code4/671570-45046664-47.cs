	public static RefGetter<T, U> create_refgetter<T, U>(String s_field)
	{
		const BindingFlags bf = BindingFlags.NonPublic |
								BindingFlags.Instance |
								BindingFlags.DeclaredOnly;
		var fi = typeof(T).GetField(s_field, bf);
		if (fi == null)
			throw new MissingFieldException(typeof(T).Name, s_field);
		var s_name = "__refget_" + typeof(T).Name + "_fi_" + fi.Name;
		// workaround for using ref-return with DynamicMethod:
		//   a.) initialize with dummy return value
		var dm = new DynamicMethod(s_name, typeof(U), new[] { typeof(T) }, typeof(T), true);
		//   b.) replace with desired 'ByRef' return value
		dm.GetType().GetField("m_returnType", bf).SetValue(dm, typeof(U).MakeByRefType());
		var il = dm.GetILGenerator();
		il.Emit(OpCodes.Ldarg_0);
		il.Emit(OpCodes.Ldflda, fi);
		il.Emit(OpCodes.Ret);
		return (RefGetter<T, U>)dm.CreateDelegate(typeof(RefGetter<T, U>));
	}
