        public static Action<IDbCommand, object> CreateParamInfoGenerator(Identity identity)
        {
            Type type = identity.parametersType;
            bool filterParams = identity.commandType.GetValueOrDefault(CommandType.Text) == CommandType.Text;
            var dm = new DynamicMethod(string.Format("ParamInfo{0}", Guid.NewGuid()), null, new[] { typeof(IDbCommand), typeof(object) }, type, true);
            var il = dm.GetILGenerator();
            il.DeclareLocal(type); // 0
            bool haveInt32Arg1 = false;
            il.Emit(OpCodes.Ldarg_1); // stack is now [untyped-param]
            il.Emit(OpCodes.Unbox_Any, type); // stack is now [typed-param]
            il.Emit(OpCodes.Stloc_0);// stack is now empty
            il.Emit(OpCodes.Ldarg_0); // stack is now [command]
            il.EmitCall(OpCodes.Callvirt, typeof(IDbCommand).GetProperty("Parameters").GetGetMethod(), null); // stack is now [parameters]
            IEnumerable<PropertyInfo> props = type.GetProperties().OrderBy(p => p.Name); 
