	public static partial class MartinMulderExtensions {
		public static IEnumerable<Type> GetMscorlibTypes() {
			return
				from assembly in AppDomain.CurrentDomain.GetAssemblies()
				let name=assembly.ManifestModule.Name
				where 0==String.Compare("mscorlib.dll", name, true)
				from type in assembly.GetTypes()
				select type;
		}
		public static IEnumerable<Type>
			InvokeZeroArgumentMethodWhichReturnsTypeOrTypes(
			this MethodInfo method, Type t
			) {
			try {
				if(typeof(Type)==method.ReturnType) {
					var type=method.Invoke(t, null) as Type;
					if(null!=type)
						return new[] { type };
				}
				if(typeof(Type[])==method.ReturnType) {
					var types=method.Invoke(t, null) as Type[];
					if(types.Length>0)
						return types;
				}
			}
			catch(InvalidOperationException) {
			}
			catch(TargetInvocationException) {
			}
			catch(TargetException) {
			}
			return Type.EmptyTypes;
		}
		public static IEnumerable<Type> GetRetrievableTypes(this Type type) {
			var typesArray=(
				from method in type.GetMethods()
				where 0==method.GetParameters().Count()
				let typeArray=
					method.InvokeZeroArgumentMethodWhichReturnsTypeOrTypes(type)
				where null!=typeArray
				select typeArray).ToArray();
			var types=
				typesArray.Length>0
					?typesArray.Aggregate(Enumerable.Union)
					:Type.EmptyTypes;
			return types.Union(new[] { type });
		}
		public static Type[] GetDesiredTypes() {
			return (
				from type in MartinMulderExtensions.GetMscorlibTypes()
				.Select(x => x.GetRetrievableTypes())
				.Aggregate(Enumerable.Union)
				where null==type.BaseType
				where type.IsClass
				where !type.IsInterface
				where !type.IsValueType
				where typeof(void)!=type
				where !type.IsByRef
				where !type.IsPointer
				select type
				).ToArray();
		}
	}
