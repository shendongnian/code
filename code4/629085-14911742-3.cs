        public DataSet OrderByDate(DateTime date)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Amrit\\Desktop\\Database.accdb ;Persist Security Info=False;";
            var dataSet = new DataSet();
            
            using(var oleConn = new OleDbConnection(connString))
            {
                try
                {
                    oleConn.Open();
                    var cmd = oleConn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Customer WHERE [Purchased Date] BETWEEN :dateStart AND :dateEnd";
                    cmd.Parameters.AddRange(new[]
                        {
                            new OleDbParameter("dateStart", date.Date),
                            new OleDbParameter("dateEnd", date.Date.AddDays(1).AddTicks(-1))
                        }
                        );
                
                    var dataAdapter = new OleDbDataAdapter(cmd);
                    dataAdapter.Fill(dataSet, "Customer");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return dataSet.Tables.Count <= 0 ? null : dataSet;
        }
