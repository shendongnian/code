    private void ProcessBatch()
    {
        using (OleDbConnection connection = new OleDbConnmection(ConnectionString))
        {
            connection.Open();
            {
                String sql = "select recid,action,parm1,parm2,parm3,parm4,targetfile from alarm.batch where recid>0 order by recid";
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int n = 0;
                        string recid_str = reader[n++].ToString();
                        string action = reader[n++].ToString();
                        string parm1 = reader[n++].ToString();
                        string parm2 = reader[n++].ToString();
                        string parm3 = reader[n++].ToString();
                        string parm4 = reader[n++].ToString();
                        string targetfile = reader[n++].ToString();
                        sql = "update alarm.batch set recid= -" + recid_str + " where recid=" + recid_str;
                        cmd = new OleDbCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        if (ProcessBatchItem(action, parm1, parm2, parm3, parm4, targetfile))
                        {
                            sql = "delete from alarm.batch where recid= -" + recid_str;
                            cmd = new OleDbCommand(sql, connection);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
