		/// <summary>
		/// Creates a SqlDataSource object using the Default connectionstring in the web.config file and returns it.
		/// </summary>
		/// <returns>An SqlDataSource that has been initialized.</returns>
		public static SqlDataSource GetDBConnection()
			{
			SqlDataSource db = new SqlDataSource();
			db.ConnectionString = GetDefaultConnectionString();
			db.ProviderName = GetDefaultProviderName();
			return db;
			}
		/// <summary>
		/// Creates a DataView object using the provided query and an SqlDataSource object.
		/// </summary>
		/// <param name="query">The select command to perform.</param>
		/// <returns>A DataView with data results from executing the query.</returns>
		public static DataView GetDataView(string query)
			{
			SqlDataSource ds = GetDBConnection();
			ds.SelectCommand = query;
			DataView dv = (DataView)ds.Select(DataSourceSelectArguments.Empty);
			return dv;
			}
