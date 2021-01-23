	void Main()
	{
		MyClass myClass = new MyClass();
		while(true)
		{
		}
	}
	public class MyClass
	{
		System.Threading.Timer _timer;
		int _functionNumber = 1;
		
		public MyClass()
		{
			_timer = new System.Threading.Timer(MyMethod, null, 0, 30000);
		}
		
		// Timer callback method
		private void MyMethod(object state)
		{
			if (_functionNumber == 1)
			{	
				function1();
				_functionNumber = 2;
			}
			else
			{
				function2();
				functionNumber = 1;
			}
		}
	
		//Function1
		public int function1()
		{
		...//some code
		}
		//function2
		public double function2()
		{
		...//some code
		}
	}
