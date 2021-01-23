	// In the base class
	public void Save() 
	{ 
		... 
		using (var transaction = BeginSharedTransaction())
		{
			SaveItem();
			
			transaction.Commit();
		}
		... 
	}
	protected virtual void SaveItem() { ... }
	// in the derived class
	public override void SaveItem()
	{
		other1.Save();
		base.SaveItem();
		other2.Save();
	}
	// In the base class (or another helper class)
	public static SqlTransaction BeginSharedTransaction()
	{
		return ... // conn.BeginTransaction();
	}
