		public class TypeComparer : IEqualityComparer<MemberInfo>
		{
			public bool Equals(MemberInfo x, MemberInfo y)
			{
				return x.ToString() == y.ToString();
			}
			public int GetHashCode(MemberInfo obj)
			{
				return obj.GetHashCode();
			}
		}
		public static bool AreTypesEqual(Type type1, Type type2)
		{
			return type1.GetMembers().
				SequenceEqual(type2.GetMembers(), new TypeComparer());
		}
