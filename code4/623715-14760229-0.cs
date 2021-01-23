	IDbCommand cmd = new SqlCommand();
	StringBuilder sb = new StringBuilder();
	sb.Append("insert into foo(col, col2, col3), values");
	
	
	for(int i = 0 ; i<3; i++)
	{
		sb.AppendFormat("( @{0}, @{1}, @{2}),", i+1, i+2, i+3);
		cmd.Parameters.Add(new SqlParameter((i+1).ToString(), ""));
		cmd.Parameters.Add(new SqlParameter((i+2).ToString(), ""));
		cmd.Parameters.Add(new SqlParameter((i+3).ToString(), ""));
	}
	sb.Append(";");
	cmd.CommandText = sb.ToString().Replace(",;", ";");
