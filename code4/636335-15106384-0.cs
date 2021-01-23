	public class Foo
	{
		public static Foo MagicalFooValue
		{
			get { return Bar.Instance; }
		}
		
		private class Bar : Foo
		{
			//Implemented as a private singleton
		}
	}
