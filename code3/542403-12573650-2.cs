    public static DataTable StatisticsGet( Guid tenantId ) {
    	DataTable result = new DataTable();
    	result.Locale = CultureInfo.CurrentCulture;
    
    	Database db = DatabaseFactory.CreateDatabase(DatabaseType.Clients.ToString());
    
    	using (DbCommand dbCommand = db.GetStoredProcCommand("reg.StatsGet")) {
    		db.AddInParameter(dbCommand, "TenantId", DbType.Guid, tenantId);
    
    		result.Load(db.ExecuteReader(dbCommand));
    	} // using dbCommand
    
    	return result;
    } // method::StatisticsGet
