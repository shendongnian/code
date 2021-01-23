    var arSample = new ArrayList();
    int gender;
    if (!int.TryParse(rbtngender.SelectedValue, out gender)) return;
    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStringNameFromWeb.Config"].ConnectionString))
    {
    	using (var cmd = new SqlCommand("storedProcName", conn))
    	{
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.Parameters.AddWithValue("@intGender", gender);
    		conn.Open();
    		using (SqlDataReader dr = cmd.ExecuteReader())
    		{
    			while (dr.Read())
    			{
    				// process each row from the data reader...
    				arSample.Add(dr["Id"]);
    			}
    		}
    		conn.Close();
    	}
    }
