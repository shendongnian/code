    using (var conn = new SqlConnection("Your ConnectionString comes here"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = 
        @"SELECT
              Contact_CardImage
          FROM 
              Ph_Tbl_Contacts 
          WHERE 
              Contact_ID = @Contact_ID
        ";
        cmd.Parameters.AddWithValue("@Contact_ID", Txt_Name.Text); 
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                byte[] raw = (byte[])reader.Items["Contact_CardImage"];
                // TODO: do something with the raw data
            }
        }
    }
