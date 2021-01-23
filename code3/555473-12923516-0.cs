    var dt1 = new CustomDataSet.CustomDataTable();
    var connectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString
    using (var connection = new SqlConnection(connectionString))
    {
    	using (var da1 = new GetCustomDataTableAdapter() { Connection = connection })
    	{
    		da1.Fill(dt1, id);
    	}	
    }
