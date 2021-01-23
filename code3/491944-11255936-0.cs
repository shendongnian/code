    using (SqlCommand sqlCommand = new SqlCommand())
    {
        SqlDataReader sqlDr = sqlCommand.ExecuteReader();
        if (!sqlDr.Read()) return;
                
        HashSet<string> fieldNames = new HashSet<string>(sqlDr.FieldCount);
        for (int i = 0; i < sqlDr.FieldCount; i++)
        {
            fieldNames.Add(sqlDr.GetName(i));
        }
        if (!fieldNames.Contains("MyField1") || !fieldNames.Contains("MyField2"))
        {
            // do something here
        }
    }
