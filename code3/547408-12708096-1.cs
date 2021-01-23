    public static void DatabindControlFromSqlQuery(Control control,string query)
    {
	    var connectionString = ConfigurationManager.ConnectionStrings["SqlConn"].ToString(); 
	    using (var connection = new SqlConnection(connectionString))
	    {
		    using (var cmd = new SqlCommand(connection))
		    {
			    cmd.CommandText = query;
			    var dt = new DataTable();
			    var adapter = new SqlDataAdapter(cmd);
			    adapter.Fill(dt);
			
			    var type = control.GetType();
			    var dataSourceProp = type.GetProperty("DataSource");
			
			    dataSourceProp.SetValue(control,dt);
			    var dataBindMethod = type.GetMethod("DataBind");
			    dataBindMethod.Invoke(control,null);
			
		    }
	    }
