	IDbCommand cmd = new SqlCommand();
	StringBuilder sb = new StringBuilder();
	sb.Append("insert into foo(col, col2, col3), values");
	int parms = 0;
	
	for(int i = 0 ; i<3; i++)
	{
		sb.AppendFormat("( @{0}, @{1}, @{2}),", parms, parms + 1, parms + 2);
		cmd.Parameters.Add(new SqlParameter((parms++).ToString(), ""));
		cmd.Parameters.Add(new SqlParameter((parms++).ToString(), ""));
		cmd.Parameters.Add(new SqlParameter((parms++).ToString(), ""));
	}
	sb.Append(";");
	cmd.Parameters;
	cmd.CommandText = sb.ToString().Replace(",;", ";");
