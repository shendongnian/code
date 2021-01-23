    public abstract class DynamicClass
    	{
    		public override string ToString()
    		{
    			PropertyInfo[] props = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
    			StringBuilder sb = new StringBuilder();
    			sb.Append("{");
    			for (int i = 0; i < props.Length; i++)
    			{
    				if (i > 0) sb.Append(", ");
    				sb.Append(props[i].Name);
    				sb.Append("=");
    				sb.Append(props[i].GetValue(this, null));
    			}
    			sb.Append("}");
    			return sb.ToString();
    		}
    	}
    
    	//DynamicTypeFactory
    	public static class ExpressionHelper //simplified
    	{
    
    		private const string DYNAMIC_ASSEMBLY_NAME = "DynamicAssembly";
    		private const string DYNAMIC_MODULE_NAME = "DynamicModule";
    		private const string DYNAMIC_CLASS_PREFIX = "DynamicClass";
    		private static ModuleBuilder _moduleBuilder;
    
    		[SecurityCritical]
    		static ExpressionHelper()
    		{
    			//var assemblyName = new AssemblyName(DYNAMIC_ASSEMBLY_NAME);
    
    			AssemblyBuilder assembly = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName(DYNAMIC_ASSEMBLY_NAME), AssemblyBuilderAccess.Run);
    			assembly.GetName().SetPublicKey(Assembly.GetExecutingAssembly().GetName().GetPublicKey());
    			assembly.GetName().SetPublicKeyToken(Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken());
    			_moduleBuilder = assembly.DefineDynamicModule(DYNAMIC_MODULE_NAME, true);
    
    		}
    
    		public static Type CreateType(IDictionary<string, Type> propertyTypes)
    		{
    			var typeName = DYNAMIC_CLASS_PREFIX + propertyTypes.GetHashCode().ToString();
    			TypeBuilder typeBuilder = _moduleBuilder.DefineType(typeName, TypeAttributes.Class | TypeAttributes.Public, typeof(DynamicClass));
    			FieldInfo[] fields = GenerateProperties(typeBuilder, propertyTypes);
    			GenerateEquals(typeBuilder, fields);
    			GenerateGetHashCode(typeBuilder, fields);
    			Type result = typeBuilder.CreateType();
    			return result;
    		}
    
    		public static object CreateObject(IDictionary<string, object> propertyValues)
    		{
    			var propertyTypes = propertyValues.ToDictionary(pair => pair.Key, pair => pair.Value == null ? typeof(object) : pair.Value.GetType());
    			var type = CreateType(propertyTypes);
    
    			Expression targetExpression = Expression.New(type.GetConstructors()[0]); 
    
    			var lambda = Expression.Lambda(targetExpression);
    			var target = lambda.Compile().DynamicInvoke();
    
    			List<MemberBinding> bindings = new List<MemberBinding>();
    
    			foreach (var pair in propertyValues)
    			{
    				bindings.Add(Expression.Bind(type.GetProperty(pair.Key), Expression.Constant(pair.Value)));
    			}
    			return Expression.Lambda(Expression.MemberInit(Expression.New(type), bindings.ToArray())).Compile().DynamicInvoke();
    		}
    
    		private static FieldInfo[] GenerateProperties(TypeBuilder typeBuilder, IDictionary<string, Type> propertyTypes)
    		{
    			FieldInfo[] fields = new FieldBuilder[propertyTypes.Count];
    			for (int i = 0; i < propertyTypes.Count; i++)
    			{
    				var dp = propertyTypes.ElementAt(i);
    				                
    				var fb = typeBuilder.DefineField("<" + dp.Key + ">k__BackingField", dp.Value, FieldAttributes.Private); //HasDefault?
    				var pb = typeBuilder.DefineProperty(dp.Key, PropertyAttributes.HasDefault, dp.Value, null);
    
    				
    				var mbGet = typeBuilder.DefineMethod("get_" + dp.Key,
    					MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, 
    					dp.Value, Type.EmptyTypes);
    				
    				var getterGenerator = mbGet.GetILGenerator();
    				getterGenerator.Emit(OpCodes.Ldarg_0);
    				getterGenerator.Emit(OpCodes.Ldfld, fb);
    				getterGenerator.Emit(OpCodes.Ret);
    				//setterBuilder
    				MethodBuilder mbSet = typeBuilder.DefineMethod("set_" + dp.Key,
    					MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, 
    					null, new Type[] { dp.Value });
    				//setterILGenerator
    				var setterGenerator = mbSet.GetILGenerator();
    				setterGenerator.Emit(OpCodes.Ldarg_0);
    				setterGenerator.Emit(OpCodes.Ldarg_1);
    				setterGenerator.Emit(OpCodes.Stfld, fb);
    				setterGenerator.Emit(OpCodes.Ret);
    				pb.SetGetMethod(mbGet);
    				pb.SetSetMethod(mbSet);
    				fields[i] = fb;
    			}
    			return fields;
    		}
    
    		private static void GenerateEquals(TypeBuilder typeBuilder, FieldInfo[] fields)
    		{
    			var mb = typeBuilder.DefineMethod("Equals",
    				MethodAttributes.Public | MethodAttributes.ReuseSlot |
    				MethodAttributes.Virtual | MethodAttributes.HideBySig,
    				typeof(bool), new Type[] { typeof(object) });
    			var generator = mb.GetILGenerator();
    			var other = generator.DeclareLocal(typeBuilder);
    			var next = generator.DefineLabel();
    			generator.Emit(OpCodes.Ldarg_1);
    			generator.Emit(OpCodes.Isinst, typeBuilder);
    			generator.Emit(OpCodes.Stloc, other);
    			generator.Emit(OpCodes.Ldloc, other);
    			generator.Emit(OpCodes.Brtrue_S, next);
    			generator.Emit(OpCodes.Ldc_I4_0);
    			generator.Emit(OpCodes.Ret);
    			generator.MarkLabel(next);
    			foreach (var field in fields)
    			{
    				var ft = field.FieldType;
    				var ct = typeof(EqualityComparer<>).MakeGenericType(ft);
    				next = generator.DefineLabel();
    				generator.EmitCall(OpCodes.Call, ct.GetMethod("get_Default"), null);
    				generator.Emit(OpCodes.Ldarg_0);
    				generator.Emit(OpCodes.Ldfld, field);
    				generator.Emit(OpCodes.Ldloc, other);
    				generator.Emit(OpCodes.Ldfld, field);
    				generator.EmitCall(OpCodes.Callvirt, ct.GetMethod("Equals", new Type[] { ft, ft }), null);
    				generator.Emit(OpCodes.Brtrue_S, next);
    				generator.Emit(OpCodes.Ldc_I4_0);
    				generator.Emit(OpCodes.Ret);
    				generator.MarkLabel(next);
    			}
    			generator.Emit(OpCodes.Ldc_I4_1);
    			generator.Emit(OpCodes.Ret);
    		}
    
    		private static void GenerateGetHashCode(TypeBuilder typeBuilder, FieldInfo[] fields)
    		{
    			var mb = typeBuilder.DefineMethod("GetHashCode",
    				MethodAttributes.Public | MethodAttributes.ReuseSlot |
    				MethodAttributes.Virtual | MethodAttributes.HideBySig,
    				typeof(int), Type.EmptyTypes);
    			var generator = mb.GetILGenerator();
    			generator.Emit(OpCodes.Ldc_I4_0);
    			foreach (FieldInfo field in fields)
    			{
    				var ft = field.FieldType;
    				var ct = typeof(EqualityComparer<>).MakeGenericType(ft);
    				generator.EmitCall(OpCodes.Call, ct.GetMethod("get_Default"), null);
    				generator.Emit(OpCodes.Ldarg_0);
    				generator.Emit(OpCodes.Ldfld, field);
    				generator.EmitCall(OpCodes.Callvirt, ct.GetMethod("GetHashCode", new Type[] { ft }), null);
    				generator.Emit(OpCodes.Xor);
    			}
    			generator.Emit(OpCodes.Ret);
    		}
    	}
