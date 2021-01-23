	public class MyClass : myInterface, myPublicInterface
	{
		private string _myProperty;
		string myInterface.myProperty
		{
			get { return _myProperty; }
			set { _myProperty = value; }
		}
		public string myProperty
		{
			get { return _myProperty; }
		}
	}
