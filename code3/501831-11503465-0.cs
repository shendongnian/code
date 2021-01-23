        try
        {
            SqlCommand cmd = new SqlCommand(query, SqlCon);
            cmd.CommandType = CommandType.Text;
            SqlCon.Open();
            cmd.Parameters.AddWithValue("@Vendor_ID", lblPage1ID.Text);
            cmd.Parameters.AddWithValue("@WorksPackage", Packagevalues);
            // add this
            cmd.ExecuteNonQuery();
        }
