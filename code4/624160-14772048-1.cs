       using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Test.mdb"))
            using (OleDbCommand Command = new OleDbCommand(" SELECT count (CustomerId) from Customer as total", con))
            {
                con.Open();
                OleDbDataReader DB_Reader = Command.ExecuteReader();
                if (DB_Reader.HasRows)
                {
                    DB_Reader.Read();
                    int id = DB_Reader.GetInt32(0);
                }
            }
