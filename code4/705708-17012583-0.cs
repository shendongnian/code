	public class DerivedClass
	{
		public string Name
		{
			get { return "Always the same"; }
			set { throw new Exception(); }
		}
	}
