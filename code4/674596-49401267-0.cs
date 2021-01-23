            string connectionString = "";
            string strFileType = "Type";
            string path = @"C:\Users\UserName\Downloads\";
            string filename = "filename.xls";
            if (fielname.Contains(.xls))
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + filename + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (fielname.Contains(.xlsx)
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + filename + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            string query = "SELECT * FROM [SheetName$]";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                var lines = new List<string>();
                while (reader.Read())
                {
                    var fieldCount = reader.FieldCount;
                    var fieldIncrementor = 1;
                    var fields = new List<string>();
                    while (fieldCount >= fieldIncrementor)
                    {
                        fields.Add(reader[fieldIncrementor - 1].ToString());
                        fieldIncrementor++;
                    }
                    lines.Add(string.Join("\t", fields));
                }
                reader.Close();
            }
