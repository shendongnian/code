     public void LoadDatabase()
	 {
	     string connectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", yourDatabaseName);
	     using (OleDbConnection con = new OleDbConnection(connectionString))
	     {
		    try
			{
				con.Open();
				var data = new DataSet();
				OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM A", con);
				adapter.Fill(data, "a");
				adapter = new OleDbDataAdapter("SELECT * FROM B", con);
				adapter.Fill(data, "b");
                // TODO: bind the control's data source to dataset
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
	    }
    }
