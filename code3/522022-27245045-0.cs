    using (OleDbDataReader reader = oledbCmd.ExecuteReader())
    {
    
        while (reader.Read())
        {
            a = reader.GetValue(0).ToString();
            b = reader.GetValue(3).ToString();
            c = reader.GetValue(4).ToString();
    
        }
    
    }
