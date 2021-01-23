       using (var connection= GetSQLiteConnection())
       {
          using (var command = new SQLiteCommand(connection))
          {
            try
            {
                command.CommandText =
                    "DELETE FROM folders WHERE path='" + path + "'";
                command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                SparkleLogger.LogInfo("CmisDatabase", e.Message);
            }
         }
      }
