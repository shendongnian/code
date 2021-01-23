    public void DBCommand(string dynSQL, bool Silent) {
        checkConnection(); //Despite the name, this "returns" void, not bool
        SqlCeCommand cmd = objCon.CreateCommand();
        SqlCeTransaction trans = GetConnection().BeginTransaction();
        cmd.Transaction = trans;
        
        var doRollback = false;
        try {
            cmd.CommandText = dynSQL;
            cmd.ExecuteNonQuery();
            trans.Commit();
        }
        catch (Exception ex) {
            doRollback = true
            MessageBox.Show(string.Format("DBCommand Except ({0})", ex.Message));
            CCR.LogMsgs.Append(string.Format("DBCommand exception: {0}\r\n", ex.Message));
        }
        finally {
            if(doRollback) }
                DoRollback();
            }
        }
    }
    
    void DoRollback(){
        try {
            trans.Rollback();
        }
        catch (SqlCeException sqlceex)  {
            MessageBox.Show(string.Format("SqlCeException ({0})", sqlceex.Message));
            CCR.LogMsgs.Append(string.Format("SqlCeException exception: {0}\r\n", sqlceex.Message));
            // Handle possible Rollback exception here
        }
    }
}
