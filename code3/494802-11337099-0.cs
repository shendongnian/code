        public string CallCardDetails(string CallCardNo)
        {
            //initialize
            using (DataSet ds = new DataSet())
            {
                //connect
                using (OracleConnection conn = new OracleConnection("User Id=oraDB;Password=ora;Data Source=CCT"))
                {
                    // Oracle uses : for parameters, not @
                    string query = "SELECT idcard from CallCardTable where idcard= :pCallCardNo";
                    // Let the using block dispose of your OracleCommand
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Note: be careful with AddWithValue: if there's a mismatch between the .NET datatype of
                        // CallCardNo and the idcard column you could have an issue.  Cast the value you provide
                        // here to whatever is closest to your database type (String for VARCHAR2, DateTime for DATE, Decimal for NUMBER, etc.)
                        cmd.Parameters.AddWithValue(":pCallCardNo", CallCardNo);
                        conn.Open();
                        // Again, wrap disposables in a using or use try/catch/finally (using will dispose of things in case of exceptions too)
                        using (OracleDataAdapter dA = new OracleDataAdapter(cmd))
                        {
                            dA.Fill(ds);
                            return ds.GetXml();
                        }
                    }
                }
            }
        }
