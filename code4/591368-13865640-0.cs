    public MainWindow()
		{
			InitializeComponent();
			Test<B> myTest = new Test<B>();
			myTest.doStuff(); // throws exception in B()
		}
		public class A
		{
			public A() { }
		}
		public class B : A
		{
			public B()
				: base()
			{
				throw new Exception();
			}
		}
		public class Test<T> where T : A, new()
		{
            // I modified this because the intent is to use T correct?
			public void doStuff() { T test = new T(); }
		}
