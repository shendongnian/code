	public class TransactionContext : ITransactionContext
	{
		protected IDbTransaction Transaction;
		protected IDbConnection Connection;
		protected readonly Func<IDbConnection> CreateConnection;
		public TransactionContext(Func<IDbConnection> createConnection)
		{
			this.CreateConnection = createConnection;
		}
		public virtual IDbConnection Open()
		{
			if (this.Connection == null)
			{
				this.Connection = this.CreateConnection();
			}
			if (this.Connection.State == ConnectionState.Closed)
			{
				this.Connection.Open();
			}
			return this.Connection;
		}
		public virtual IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
		{
			Open();
			return this.Transaction ?? (this.Transaction = this.Connection.BeginTransaction(isolationLevel));
		}
		public virtual void CommitTransaction()
		{
			if (this.Transaction != null)
			{
				this.Transaction.Commit();
			}
			this.Transaction = null;
		}
		public virtual void RollbackTransaction()
		{
			if (this.Transaction != null)
			{
				this.Transaction.Rollback();
			}
			this.Transaction = null;
		}
		public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
		{
			Open();
			using (var cmd = CreateCommand(sql, parameters))
			{
				return cmd.ExecuteNonQuery();
			}
		}
		public virtual IEnumerable<T> SqlQuery<T>(string sql, object[] parameters ) 
		{
			return SqlQuery<T>(sql, parameters, null);
		}
		public IEnumerable<T> SqlQuery<T>(string sql, object[] parameters, IDictionary<string, string> mappings) 
		{
			var list = new List<T>();
			var converter = new DataConverter();
			Open();
			using (var cmd = CreateCommand(sql, parameters))
			{
				var reader = cmd.ExecuteReader();
				if (reader == null)
				{
					return list;
				}
				var schemaTable = reader.GetSchemaTable();
				while (reader.Read())
				{
					var values = new object[reader.FieldCount];
					reader.GetValues(values);
					var item = converter.GetObject<T>(schemaTable, values, mappings);
					list.Add(item);
				}
			}
			return list;		}
		public virtual bool Exists(string sql, params object[] parameters)
		{
			return SqlQuery<object>(sql, parameters).Any();
		}
		protected virtual IDbCommand CreateCommand(string commandText = null, params object[] parameters)
		{
			var command = this.Connection.CreateCommand();
			if (this.Transaction != null)
			{
				command.Transaction = this.Transaction;
			}
			if (!string.IsNullOrEmpty(commandText))
			{
				command.CommandText = commandText;
			}
			if (parameters != null && parameters.Any())
			{
				foreach (var parameter in parameters)
				{
					command.Parameters.Add(parameter);
				}
			}
			return command;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected void Dispose(bool disposing)
		{
			
			if (this.Connection != null)
			{
				this.Connection.Dispose();
			}
			this.Connection = null;
			this.Transaction = null;
		}
	}
