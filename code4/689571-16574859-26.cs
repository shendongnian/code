	public interface ITransactionContext : IDisposable
	{
		IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
		void CommitTransaction();
		void RollbackTransaction();
		int ExecuteSqlCommand(string sql, params object[] parameters);
		IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);
		
		IEnumerable<T> SqlQuery<T>(string sql, object[] parameters, IDictionary<string, string> mappings);
		bool Exists(string sql, params object[] parameters);		
	}
	public interface ITransactionDbContext : ITransactionContext
	{
		int SaveChanges();
	}
