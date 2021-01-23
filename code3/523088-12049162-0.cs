        public static void Main(string[] Arguments)
        {
            try
            {
                string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"Test.xlsx\";Extended Properties=\"Excel 12.0;HDR=Yes;READONLY=FALSE\"";
                DataTable dataTable = new DataTable();
                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    conn.Open();
                    string selectQuery = "SELECT 0 As IsProcessed, * INTO [Excel 12.0;HDR= Yes;DATABASE=Test.xlsx].[copyd]  FROM [TestWorkSheet1$]";
                    OleDbCommand cmd = new OleDbCommand(selectQuery, conn);
                    int count = cmd.ExecuteNonQuery();
                    Console.WriteLine(count.ToString());
                    conn.Close();
                }
            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
