	public class DataAccess
	{
	   private DbProviderFactory factory;
	   private DbConnection connection;
	   public enum Provider
	   { SQL, Access } 
	   public DataAccess(Provider provider)
	   {
			switch (provider)
			{
				case Provider.Ole:
					factory = DbProviderFactories.GetFactory("System.Data.OleDb");
					break;
				case Provider.Sql:
					factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
					break;
			}
			this.connection = factory.CreateConnection();
	   }
   
        public DbDataReader GetDataReader(string statement, params DbParameter[] parameters)
        {
            using (DbCommand command = factory.CreateCommand())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.CommandText = statement;
                command.Connection = connection;
                parameters.ToList().ForEach(x => command.Parameters.Add(x));
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
	}
   
