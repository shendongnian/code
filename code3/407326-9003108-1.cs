	string QueryDate = monthCalendar1.SelectionRange.Start.ToString();
	QueryDate = QueryDate.Substring(0, 10);
	string connstr = "Provider=Microsoft.Jet.Oledb.4.0;DataSource=data.mdb";
	string query = "Select Rezerve from 101 Where Tarih=@QueryDate";
	using (OleDbConnection dc = new OleDbConnection(connstr))
    {
		OleDbCommand sqlcmd = new OleDbCommand(query, conn);
		sqlcmd.Parameters.AddWithValue("@QueryDate", QueryDate);
		bool Rezerve = (bool)sqlcmd.ExecuteScalar();
	}
    switch (Rezerve) 
	{ 
		Case true: 
			//true stuff 
			break; 
		Case false: 
			//false stuff 
			Break; 
		Default: 
			//No Return 
			Break; 
	}
