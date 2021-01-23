       static void Main(string[] args)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbFile = filePath + @"\sqlfile.txt";
            writeFileFromDB(dbFile);
        }
        public static void writeFileFromDB(string dbFile)
        {
            //create connection
            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(@"MY DB CONNECTION STRING");
            String sql = @"SELECT COLUMN1, COLUMN2
                           FROM Export.TABLENAME";
            comm.CommandText = sql;
            comm.Connection.Open();
            SqlDataReader sqlReader = comm.ExecuteReader();
            // Open the file for write operations.  If exists, it will overwrite due to the "false" parameter
            using (StreamWriter file = new StreamWriter(dbFile, false))
            {
                while (sqlReader.Read())
                {
                    file.WriteLine(sqlReader["COLUMN1"] + "\t" + sqlReader["COLUMN2"]);
                }
            }
            sqlReader.Close();
            comm.Connection.Close();
        }
