    class MainClass
	{
		public static void Main (string[] args)
		{
			var test = new SampleClass(); 
			test.MyTransactionDelegate += () => {Console.WriteLine("Success");}; 
			test.DoSomething(); 
		}
	}
