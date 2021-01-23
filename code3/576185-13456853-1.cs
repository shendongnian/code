    using (var writer = new StreamWriter(saveFileDialog1.FileName))
    {
        using (SqlCommand command = new SqlCommand(consulta, SqlConn))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader != null && reader.Read())
                {
                    writer.AppendFormat(
    "{0,-5}  {1,-10}  {2,-10} {3,-18} {4,-10}  {5,-2}  {6,-10} {7,-5} {8,-10}", 
                        Convert.ToString(reader[0]),
                        reader.GetDateTime(1).ToString("yyyy-MM-dd"),
                        reader.GetDateTime(2).ToString("yyyy-MM-dd"),
                        Convert.ToString(reader[3]),
                        Convert.ToString(reader[4]), 
                        "06",
                        Convert.ToString(reader[5]),
                        Convert.ToString(reader[6]),
                        Convert.ToString(reader[7]));
                    writer.AppendLine();
               }
           }
        }
    }
