            //ExcelDA Class
            public ExcelDA()
        {
            connString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ofd.FileName + "; Extended Properties=" + '"' + "Excel 8.0; HDR=Yes; IMEX=1" + '"';
        }
        /// <summary>
        /// Method used to retrieve a datatable from excel sheet
        /// </summary>
        public DataTable GetProductsExcel()
        {
            StringBuilder excBuilder = new StringBuilder();
            excBuilder.Append("SELECT * FROM [Sheet1$];");
            //
            try
            {
                return ExecuteSqlStatement(excBuilder.ToString());
            }
            catch (Exception) 
            { 
                MessageBox.Show("Error retreiving data");
                return null;
            }
        }
        private DataTable ExecuteSqlStatement(string command)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OleDbDataAdapter adaptor = new OleDbDataAdapter(command, conn))
                    {
                        DataTable table = new DataTable();
                        adaptor.Fill(table);
                        return table;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }
        //SqlDA class
        public void ExecuteSQLCommand(string comm)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(comm, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (SqlException ex) { throw ex; }
        }
        public void AddNames(string fName, string sName)
        {
              StringBuilder sqlQuery = new StringBuilder();
              //build sql insert statement here
              ExecuteSQLCommand(sqlBuilder.ToString());
        }
        
        //Program class
        ExcelDA reader = new ExcelDA();
        DataTable names = reader.GetSuppliersExcel();
        //string array to store excel row data for names
        string[] arr2 = new string[2] { "", ""};
            //recursive loop to retrieve each row and values from each rows columns
            foreach (DataRow row in suppliers.Rows)
            {
                for (int i = 0; i < names.Columns.Count; i++)
                {
                    if (i == (names.Columns.Count - 1))
                    {
                        arr2[i] = (row[i].ToString());
                    }
                    else
                    {
                        arr2[i] = (row[i].ToString());
                    }
                }
            }
                try
                {
                    sql.AddNames(arr2[0], arr2[1]);
                    Console.WriteLine("Added Data to SQL");
                }
                catch (Exception) { }
