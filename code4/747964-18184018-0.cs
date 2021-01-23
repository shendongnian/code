    try
    {
        using (var connection = new OleDbConnection(Properties.Settings.Default.AccountingServicesConnectionString))
        using (var cmd = connection.CreateCommand())
        {
            connection.Open();
            cmd.CommandText = string.Format("UPDATE [{0}] SET [{1}] = ? WHERE [Luna] = ?", tableName, entryName);
            cmd.Parameters.AddWithValue("?", entryNewValue);
            cmd.Parameters.AddWithValue("?", this.key);
            cmd.ExecuteNonQuery();
            return entryNewValue;
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex); // <=== put breakpoint here
        throw;
    }
