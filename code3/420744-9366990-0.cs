    var sl = new List<string>();
    // Edit accordingly
    string sql = "";
    // Edit accordingly
    string cs = "Data Source= ;Initial Catalog= ;Integrated Security= ;";
    using (var conn = new SqlConnection(cs))
    {
	    conn.Open();
		using (var cmd = new SqlCommand(sql, conn))
		{
			using (var dr = new command.ExecuteReader())
			{
				var myRow = dr["MyColumn"];
				sl.Add(myRow.ToString());
			}
		}
	}
