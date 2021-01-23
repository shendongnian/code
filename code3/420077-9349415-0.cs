    public void BackupDatabase()
    {
      /// this method should get opened connection
      SqlConnection conn = GetOpenedDBConnectionFromSomewhere();
      string dbName = conn.Database;
      string backupFName = "c:\\MSSQLData\\Backup\\" + dbName + "_" + DateTime.Now.Ticks.ToString() + ".bak";
      string sql = "BACKUP DATABASE [" + conn.Database + "] TO DISK = '" + backupFName + "'" +
                   "WITH NOFORMAT, INIT,  NAME = 'Backup of DB:" + dbName + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;";
      using (SqlCommand cmd = new SqlCommand(sql, conn))
      {
        cmd.ExecuteNonQuery();
      }
    }
