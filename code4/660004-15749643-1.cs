    public void DBCommand(SqlCeCommand cmd, string dynSQL, bool Silent) {
      cmd.CommandText = dynSQL;
      DBCommand(cmd, Silent);
    }
    public void DBCommand(SqlCeCommand cmd, bool Silent) {
      string dynSQL = cmd.CommandText;
      SqlCeTransaction trans = GetConnection().BeginTransaction();
      cmd.Transaction = trans;
      try {
        cmd.ExecuteNonQuery();
        trans.Commit();
      } catch (Exception ex) {
        try {
          trans.Rollback(); // I was under the impression you never needed to call this.
          // If Commit is never called, the transaction is automatically rolled back.
        } catch (SqlCeException) {
          // Handle possible exception here
        }
        MessageBox.Show("DBCommand Except 2"); // This one I haven't seen...
        //WriteDBCommandException(dynSQL, ex, Silent);
      }
    }
