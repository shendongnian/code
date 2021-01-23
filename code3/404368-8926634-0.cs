    protected void autocomplete(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(zipcode.Text))
            return;
		string query = @"
			SELECT area FROM tbl_pincode WHERE area LIKE @Value
			UNION 
			SELECT codes FROM tbl_pincode WHERE codes LIKE @Value";
			
		SqlConnection conn = null;
		SqlCommand com = null;
		SqlDataReader dr = null;
		try
		{
			conn = new SqlConnection("Data Source=win2008-2;Initial       Catalog=h1tm11;User ID=sa;Password=#1cub3123*;Persist Security Info=True;");
			com = new SqlCommand(query, conn);
			string value = string.Format("{0}%", zipcode.Text);
			com.Parameters.AddWithValue("@Value", value);
			conn.Open();
			dr = com.ExecuteReader();
			if (dr.Read())
			{
				zipcode.Text = dr.GetValue(0).ToString();
			}
		}
		finally
		{
			if (conn != null) conn.Dispose();
			if (dr != null) dr.Dispose();
			if (com != null) com.Dispose();
		}
	}
