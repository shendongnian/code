	public sealed class MyTransactionScope : IDisposable
	{
		TransactionScope _transactionScope = null;
		#region Overloaded Constructors
		public MyTransactionScope()
		{
			_transactionScope = new TransactionScope();
		}
		public MyTransactionScope(Transaction transactionToUse)
		{
			_transactionScope = new TransactionScope(transactionToUse);
		}
		#endregion
		public void Complete()
		{
			_transactionScope.Complete();
		}
		public void Dispose()
		{
			_transactionScope.Dispose();
		}
	}
