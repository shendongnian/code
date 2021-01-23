	try
	{
		using(OracleCommand oc = new OracleCommand(query, con))
		{
			oc.CommandType = CommandType.Text;
			String s = oc.ExecuteScalar().ToString();
			return s;
		}
	}
	catch (OracleException ex)
	{
		// either do something meaningful here, or fail hard
		MessageBox.Show(ex.Message);
		throw;
	}
