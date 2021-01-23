        using (System.Data.IDbConnection idbc = new System.Data.SqlClient.SqlConnection("connectionstring"))
        {
            lock (idbc)
            {
                using (System.Data.IDbCommand cmd = idbc.CreateCommand())
                {
                    lock (cmd)
                    {
                        cmd.CommandText = "INSERT INTO Customer1 (FirstName, LastName, Address, City, State, Zip, Phone, Notes) Values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)";
                        System.Data.IDbDataParameter parm = cmd.CreateParameter();
                        parm.DbType = System.Data.DbType.AnsiString;
                        parm.ParameterName = "@p1";
                        parm.Value = "ValueOfP1";
                        cmd.Parameters.Add(parm);
                        //
                        if (cmd.Connection.State != System.Data.ConnectionState.Open)
                            cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        if (cmd.Connection.State != System.Data.ConnectionState.Closed)
                            cmd.Connection.Close();
                    }
                }
            }
        }
