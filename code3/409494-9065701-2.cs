    var loans = new DataTable();
	loans.Columns.Add("lookupcode", typeof(string), 10);
	using(SqlCommand cmd = new SqlCommand("SelectLoansByCodes", conn)
	{
	  cmd.CommandType = CommandType.StoredProcedure;
	  cmd.Parameters.AddWithValue("Loans", loans);
          SqlDataReader reader =
            cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]));
        }
	}
