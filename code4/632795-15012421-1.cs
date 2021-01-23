		public static bool AreTypesEqual2(Type type1, Type type2)
		{
			return type1.GetMembers().OrderBy(e=>e.ToString()).
				SequenceEqual(type2.GetMembers().OrderBy(e=>e.ToString()), new TypeComparer());
		}
