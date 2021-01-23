	public abstract class BaseClass
	{
		public string str()
		{
			return "Hello my name is " + Name;
		}
		protected abstract string Name { get; }
	}
