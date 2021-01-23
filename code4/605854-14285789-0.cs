	public static class FooExtensions
	{
		public static string Name(this Foo Value)
		{
			var Type = Value.GetType();
			var Name = Enum.GetName(Type, Value);
			if (Name == null)
				return null;
			var Field = Type.GetField(Name);
			if (Field == null)
				return null;
			var Attr = Field.GetCustomAttribute<BarAttribute>();
			if (Attr == null)
				return null;
			return Attr.Name;
		}
	}
