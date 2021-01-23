     var sb = new StringBuilder();
     while (sqlReader.Read())
     {
         sb.AppendLine(sqlReader.GetString(0));
     }
     nameTextBlock.Text = sb.ToString();
