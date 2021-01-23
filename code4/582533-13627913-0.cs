        static void Main(string[] args)
        {
            string dbPath = null;
            if (args.Length > 0)
            {
                dbPath = args[0];
                string connectionString = "PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=" + dbPath + ";";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    
                    //TODO: handle other db commands...
                }
            }
        }
