	using( SqlConnection cn = new SqlConnection( "Your Conn String" ) )
	{
		string sqlSelect = "SELECT STATEMENT";
		using( SqlDataAdapter da = new SqlDataAdapter( sqlSelect, cn ) )
		{
			DataTable dt = new DataTable();
			da.Fill( dt );
            //bind data
		}
	}
