	[ContractClassFor(typeof(IAccount))]
	public abstract class MyClassContract : IAccount
	{
		public abstract double Balance { get; }
		void IAccount.Deposit(double amount)
		{
			Contract.Requires(amount >= 0.0d);
			//throw new NotImplementedException();
		}
		bool IAccount.Withdraw(double amount)
		{
			Contract.Requires(amount >= 0.0d);
			Contract.Requires(amount <= Balance);
			throw new NotImplementedException();
		}
		[ContractInvariantMethod]
		private void ObjectInvariants()
		{
			Contract.Invariant(Balance >= 0.0d);
		}
	}
