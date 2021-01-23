    private DataTable LoadXLS(string filePath)
        {
            DataTable table = new DataTable();
            DataRow row;
            try
            {
                using (OleDbConnection cnLogin = new OleDbConnection())
                {
                    cnLogin.ConnectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filePath + "';Extended Properties=Excel 8.0;";
                    cnLogin.Open();
                    string sQuery = "SELECT * FROM  [Sheet1$]";
                    table.Columns.Add("Tags", typeof(string));
                    table.Columns.Add("ReplaceWords", typeof(string));
                    OleDbCommand comDB = new OleDbCommand(sQuery, cnLogin);
                    using (OleDbDataReader drJobs = comDB.ExecuteReader(CommandBehavior.Default))
                    {
                        while (drJobs.Read())
                        {
                            row = table.NewRow();
                            row["Tags"] = drJobs[0].ToString();
                            row["ReplaceWords"] = drJobs[1].ToString();
                            table.Rows.Add(row);
                        }
                    }
                }
                return table;
            }
