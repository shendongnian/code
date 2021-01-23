    if (dc.SqlConnection.State != ConnectionState.Open) 
        dc.SqlConnection.Open();
        
    using (var cmd = new SqlCommand("GetDetailsByEmail", dc.SqlConnection))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        
        foreach (Microsoft.Office.Interop.Outlook.MailItem mail in items)
        {
            if (mail.UnRead)
            {
                e = mail.SenderEmailAddress;
                // param   <-- add sql parameters
                cmd.Parameters.AddWithValue("@epost", e);
  
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        uid = reader.GetInt32(0);
                       
                        DataRow row = dt.NewRow();
                        row["id"] = sid;
                        sid++;
                        row["uid"] = uid;// uid
                        row["email"] = e;
                        dt.Rows.Add(row);
                    }
                }
            }
        }
    }
