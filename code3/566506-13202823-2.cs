        using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
		{
			using(SqlCommand cmd = new SqlCommand("SELECT count(*) from MyTabel WHERE ID =@ID And (Field1='Yes' And Field2='Yes')" , con))
			{
				cmd.parameters.Add("@ID",Request.QueryString["ID"]);
				
				con.open();
				
				int result = cmd.ExecuteScalar();
				
				con.close();
				
				if(result == 1)
					// condition exists
					// so call success function
				else
					// call failure function
			}
		}
