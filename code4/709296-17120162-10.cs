    class DynamicProperty<T>
    {
        public DynamicProperty(TypeBuilder builder, string name)
        {
            var field = builder.DefineField("_" + name, typeof(T), FieldAttributes.Private);
            var property = builder.DefineProperty(name, PropertyAttributes.None, typeof(T), new Type[0]);
            var getter = builder.DefineMethod("get_" + name, MethodAttributes.Public | MethodAttributes.SpecialName, typeof(T), new Type[0]);
            var setter = builder.DefineMethod("set_" + name, MethodAttributes.Public | MethodAttributes.SpecialName, null, new Type[] { typeof(T) });
            var getGenerator = getter.GetILGenerator();
            var setGenerator = setter.GetILGenerator();
            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Ldfld, field);
            getGenerator.Emit(OpCodes.Ret);
            
            setGenerator.Emit(OpCodes.Ldarg_0);
            setGenerator.Emit(OpCodes.Ldarg_1);
            setGenerator.Emit(OpCodes.Stfld, field);
            setGenerator.Emit(OpCodes.Ret);
            property.SetGetMethod(getter);
            property.SetSetMethod(setter);
        }
    }
