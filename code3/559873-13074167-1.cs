        static void Main(string[] args)
        {
            var timer = new System.Diagnostics.Stopwatch();
            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=\"Excel 12.0;HDR=YES;\";Data Source=Book1.xlsx";
                using (OleDbConnection oleDbConnection = new OleDbConnection(connectionString))
                {
                    oleDbConnection.Open();
                    string szHeaderSelect = "SELECT [A1] FROM  from [Sheet1$]";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(szHeaderSelect, oleDbConnection))
                    {
                        using (da.InsertCommand = new OleDbCommand("INSERT INTO [Sheet1$] ( [A1] ) VALUES (?)",
                            oleDbConnection))
                        {
                            da.InsertCommand.Parameters.Add("A1", OleDbType.Integer, 20, "[A1]");
                            List<int> testData = new List<int>();
                            for (int i = 1; i < 400000; i++)
                            {
                                testData.Add(i);
                            }
                            DataSet dsTest = new DataSet();
                            dsTest.Tables.Add("[Sheet1$]");
                            dsTest.Tables[0].Columns.Add("[A1]");
                            foreach (int number in testData)
                            {
                                DataRow drNew = dsTest.Tables[0].NewRow();
                                drNew["[A1]"] = number;
                                dsTest.Tables[0].Rows.Add(drNew);
                            }
                            timer.Start();
                            var recs = da.Update(dsTest, "[Sheet1$]");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            finally
            {
                timer.Stop();
                Console.WriteLine(timer.Elapsed);
            }
            // Don't close before I get to read the results
            Console.WriteLine();
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
