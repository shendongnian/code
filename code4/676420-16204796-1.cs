    public abstract class Foo
	{
		public void Access(Foo foo)
		{
			if (foo.GetType() == GetType())
			{
				AccessIfSameImplementation(foo);
			}
			else
			{
				AccessIfDifferentImplementation(foo);
			}
		}
		protected abstract void AccessIfSameImplementation(Foo foo);
		private void AccessIfDifferentImplementation(Foo foo)
		{
			//do stuff with the different implementations
		}
	}
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
    }
   
	
