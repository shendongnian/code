    class Foo
	{
		public int Id { get; set; }
		
		public static bool operator ==(Foo first, Foo second)
		{
			return first.Id == second.Id;
		}
		
		public static bool operator !=(Foo first, Foo second)
		{
			return first.Id != second.Id;
		}
	}
