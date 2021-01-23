    using System.Data;
    using System.Data.OleDb;
    
    namespace Data_Migration_Process_Creator
    {
        class Class1
        {
            private DataTable GetDataTable(string sql, string connectionString)
            {
                DataTable dt = null;
    
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                            return dt;
                        }
                    }
                }
            }
    
            private void GetExcel()
            {
                string fullPathToExcel = "<Path to Excel file>"; //ie C:\Temp\YourExcel.xls
                string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=yes'", fullPathToExcel);
                DataTable dt = GetDataTable("SELECT * from [SheetName$]", connString);
    
                foreach (DataRow dr in dt.Rows)
                {
                    //Do what you need to do with your data here
                }
            }
        }
    }
