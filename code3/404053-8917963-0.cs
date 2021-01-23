	public class MyClass
	{
		private int _myProp;
		private int MyProp
		{
			get { return _myProp; }
			set 
			{
				if (_myProp == 0)
					_myProp = value
				else
					throw new Exception();
			}
		}
	}
