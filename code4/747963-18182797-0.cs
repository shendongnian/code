    try {
        using(var connection = new OleDbConnection(Properties.Settings.Default.AccountingServicesConnectionString))
        using(var cmd = connection.CreateCommand())
        {
            connection.Open();
            cmd.CommandText = string.Format(
                "UPDATE {0} SET {1} = {2} WHERE Luna = \"{3}\"",
                tableName, entryName, entryNewValue, this.key);
            cmd.ExecuteNonQuery(); // I think here is my problem!
            return entryNewValue;
        }
    } catch(Exception ex) {
         SomeGlobalLogging(ex); // <=== put breakpoint here
         throw;
    }
