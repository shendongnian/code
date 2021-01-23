    using (reader = command.ExecuteReader())
    {
        var sb = new StringBuilder();
        while (reader.Read())
        {
            sb.Append(reader["col1"].ToString());
        }
        Div1.InnerHtml = sb.ToString();
    }
