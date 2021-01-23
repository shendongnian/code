	partial class MartinMulderExtensions {
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
	}
