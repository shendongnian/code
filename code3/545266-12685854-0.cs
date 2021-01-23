        public static int GetAndSetMaxIdTable(DbProviderFactory factory, DbConnection cnctn,   DbTransaction txn, int numberOfIds)
        {
                bool noPrevRow = false;
                int realMaxId;
         
                using (DbCommand getCmd = cnctn.CreateCommand())
                {
                    getCmd.CommandText = "SELECT MaxId FROM IdMax WITH (TABLOCKX)"
                    getCmd.Transaction = txn;
                    object o = getCmd.ExecuteScalar();
                    if (o == null)
                    {
                        noPrevRow = true;
                        realMaxId = 0;
                    }
                    else
                    {
                        realMaxId = Convert.ToInt32(o);
                    }
                }
                using (DbCommand setCmd = cnctn.CreateCommand())
                {
                    if (noPrevRow)
                        setCmd.CommandText = CreateInsertCommand(factory, tableId, userName, numberOfIds, realMaxId, setCmd, txn);
                    else
                        setCmd.CommandText = CreateUpdateCommand(factory, tableId, userName, numberOfIds, realMaxId, setCmd, txn);
                    setCmd.ExecuteNonQuery();
                }
                return realMaxId;
        }
