    using (var writer = new StreamWriter(saveFileDialog1.FileName))
    {
        using (SqlCommand command = new SqlCommand(consulta, SqlConn))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader != null && reader.Read())
                {
                    writer.AppendFormat("{0, -7}", reader[0]);
                    writer.AppendFormat("{0:yyyy-MM-dd, -12}", reader.GetDateTime(1));
                    writer.AppendFormat("{0:yyyy-MM-dd, -11}", reader.GetDateTime(2));
                    writer.AppendFormat("{0, -19}", reader.[3]);
                    writer.AppendFormat("{0, -12}06", reader.[4]);
                    writer.AppendFormat("{0, -11}, reader.[5]);
                    writer.AppendFormat("{0, -6}, reader.[6]);
                    writer.AppendFormat("{0, -10}, reader.[7]);
                    writer.AppendLine();
               }
           }
        }
    }
