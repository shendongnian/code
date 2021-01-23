    public class Bar : Foo
	{
		public string Baz { get; set; }
		protected override void AccessIfSameImplementation(Foo foo)
		{
			var bar = foo as Bar;
			if (bar == null)
			{
				throw new ArgumentException("Argument foo is not of type Bar");
			}
			//Do Bar stuff below
			bar.Baz = "Yay!";
		}
	
