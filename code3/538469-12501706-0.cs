    ...
    using StackExchange.Profiling;
    using StackExchange.Profiling.Data;
    ...
    using( DbConnection conn = new ProfiledDbConnection( new SqlConnection( ConnectionString ), MiniProfiler.Current ) ) {
			using( DbCommand command = conn.CreateCommand() ) {
				command.CommandText = CommandText;
				command.Connection = conn;
				command.CommandType = SQLCommandType;
				foreach( SqlParameter p in ParamsToAdd ) {
					command.Parameters.Add( p );
				}
				conn.Open();
				DbDataReader rdr;
				try {
					rdr = command.ExecuteReader();
				} catch( Exception ex ) {
					//log error
				}
				using( rdr ) {
					while( rdr.Read() ) {
						yield return (IDataRecord)rdr;
					}
				}
			}
		}
