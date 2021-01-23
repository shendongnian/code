		using (MySqlConnection conn = fahad.conncting())
		using (MySqlCommand cmd = new MySqlCommand("select * from table", conn))
		using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
		using (DataTable dt = new DataTable())
		{
			da.Fill(dt);
			// do something with datatable
		}
	
