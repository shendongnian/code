            try
            {
                erplibmain.erpDac.runOleDbTransaction(commandList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        public void runOleDbTransaction(List<Command> commandList)
        {
            OleDbConnection erpConnection = new OleDbConnection(ErpDalMain.connectionstring);
            erpConnection.Open();
            OleDbCommand erpCommand = erpConnection.CreateCommand();
            OleDbTransaction erpTrans;
            // Start a local transaction
            erpTrans = erpConnection.BeginTransaction();
            // Assign transaction object for a pending local transaction
            erpCommand.Connection = erpConnection;
            erpCommand.Transaction = erpTrans;
            try
            {
                foreach (Command cmd in commandList)
                {
                    erpCommand.CommandText = cmd.sql;
                    erpCommand.CommandType = cmd.cmdType;
                    foreach (KeyValuePair<string, object> entry in cmd.parameter)
                    {
                        erpCommand.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    erpCommand.ExecuteNonQuery();
                    erpCommand.Parameters.Clear();
                }
                erpTrans.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    erpTrans.Rollback();
                }
                catch (OleDbException ex)
                {
                    if (erpTrans.Connection != null)
                    {
                        throw ex;
                    }
                }
                throw e;
            }
            finally
            {
                erpConnection.Close();
            }
        }
