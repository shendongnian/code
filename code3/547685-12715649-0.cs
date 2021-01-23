            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=d:\temp\Book1.xlsx; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            string queryString = "SELECT * FROM [CE$]";
            OleDbDataReader reader;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(queryString, connection);
                connection.Open();
                DataSet ds = new DataSet("Book1");
                IDataAdapter adapter = new OleDbDataAdapter(queryString, connection);
                adapter.Fill(ds);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Id = "";
                    string courseCode = "";
                    string partner = "";
                    string effectiveDate = "";
                    string expirationDate = "";
                    Id = reader[0].ToString();
                    courseCode = reader[1].ToString();
                    partner = reader[2].ToString();
                    effectiveDate = reader[3].ToString();
                    expirationDate = reader[4].ToString();
                    //Id = reader.GetString(0);
                    //courseCode = reader.GetString(1);
                    //partner = reader.GetString(2);
                    //effectiveDate = reader.GetString(3);
                    //expirationDate = reader.GetString(4);
                }
            }
