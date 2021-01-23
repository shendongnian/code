    class SampleClass
	{
		public delegate void TransactionDelegate(); 
		public event TransactionDelegate MyTransactionDelegate;
		public void DoSomething()
		{
			MyTransactionDelegate(); 
		}
	}
