    string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=msdb;Integrated Security=True;";
	SqlConnection conn = new SqlConnection(connString);
	
	try
	{
	using (SqlCommand cmd = conn.CreateCommand())
		{
			cmd.CommandText = "select  from MSdbms"; //Will throw an exception - Invalid SQL syntax
			conn.Open();
			Console.WriteLine(conn.State);
			using (IDataReader reader = cmd.ExecuteReader())
			{
				Console.WriteLine("here");
			}
		}
	}
	catch(Exception ex)
	{  Console.WriteLine(conn.State); } //prints Open
