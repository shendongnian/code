	// In the base class
	protected SqlTransaction Transaction;
	public void Save() 
	{ 
		... 
		using (var transaction = BeginSharedTransaction())
		{
			Save(Transaction);
			transaction.Commit();
		}
		... 
	}
	public void Save(SqlTransaction transaction) 
	{ 
		Transaction = transaction;
		SaveItem();
	}
	protected virtual void SaveItem() { ... /* uses Transaction on all SQL commands */ ... }
	// in the derived class
	public override void SaveItem()
	{
		other1.Save(Transaction);
		base.SaveItem();
		other2.Save(Transaction);
	}
	// In the base class (or another helper class)
	public static SqlTransaction BeginSharedTransaction()
	{
		return ... // conn.BeginTransaction();
	}
