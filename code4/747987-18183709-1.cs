    public static void appenddatatotable2(string connectionstring, string tablename, string datstr, List<PowRes> values)
            {
                string commandText = "INSERT INTO " + tablename + " ([RunDate],[ReportingGroup], [Tariff], [Year]) VALUES(@RunDate, @ReportingGroup, @Tariff, @Year)";
                using (var myconn = new OleDbConnection(connectionstring))
                {
                    myconn.Open();
                    using (var cmd = new OleDbCommand())
                    {
                        foreach (var item in values)
                        {
                            cmd.CommandText = commandText;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(new[] { new OleDbParameter("@RunDate", datstr), new OleDbParameter("@ReportingGroup", item.RG), new OleDbParameter("@Tariff", item.tar), new OleDbParameter("@Year", item.yr) });
                            cmd.Connection = myconn;
                            cmd.Prepare(); 
                            cmd.ExecuteNonQuery();
                        }
                    }   
                }
            }
