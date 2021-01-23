	public class DBOperations : IDisposable
	{
		NorthwindEntities _context;
		private TransactionScope _transactionScope;
		public DBOperations()
		{
			this.Initialize();
		}
		private void Initialize()
		{
			try
			{
				this.Dispose();
				this._transactionScope = new TransactionScope();
				this._context = new NorthwindEntities();
				// no need to open connection. Let EF manage that.
			}
			catch (Exception ex)
			{
				throw new Exception("Database Error " + ex.Message);
			}
		}
		public void RollbackTransaction()
		{
				try
				{
					this._transactionScope.Dispose();
					this._transactionScope = null;
					this.Dispose();
					this.Initialize();
				}
				catch (Exception)
				{
					// TODO
				}
		}
		public int UpdateDB()
		{
			int _returnVal = 0;
			try
			{
				this._context.ExecuteStoreCommand("UPDATE Orders SET OrderDate = GETDATE() WHERE OrderID = '10248'");
			}
			catch (Exception ex)
			{
				throw new Exception("Database Error " + ex.Message);
			}
			return _returnVal;
		}
		public void Dispose()
		{
			if (this._transactionScope != null)
			{
				this._transactionScope.Complete();
				this._transactionScope.Dispose();
			}
			if (this._context != null) this._context.Dispose();
		}
	}
