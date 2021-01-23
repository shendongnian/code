    var commandStrings = Regex.Split(
        Resources.DatabaseScript,
        "^\\s*GO\\s*$",
        RegexOptions.Multiline | RegexOptions.Compiled);
    // container is my EDMX container.
    container.Connection.Open();
    try
    {
        using (var transaction = container.Connection.BeginTransaction())
        {
            try
            {
                foreach (var commandInput in commandStrings.Where(commandInput => !string.IsNullOrWhiteSpace(commandInput)))
                {
                    Debug.Write("Executing SQL ... ");
                    try
                    {
                        using (var command = container.Connection.CreateCommand())
                        {
                            command.Connection = container.Connection;
                            command.Transaction = transaction;
                            command.CommandText = commandInput;
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                        }
                        Debug.WriteLine("Success!");
                    }
                    finally
                    {
                        Debug.WriteLine("SQL: " + commandInput);
                    }
                }
                transaction.Commit();
            }
            catch (Exception exc)
            {
                Debug.WriteLine("Failed!");
                Debug.WriteLine("Exception: " + exc.Message);
                Debug.Write("Rolling back ... ");
                try
                {
                    transaction.Rollback();
                    Debug.WriteLine("Success!");
                }
                catch (Exception exce)
                {
                    Debug.WriteLine("Exception: " + exce.Message);
                }
            }
        }
    }
    finally
    {
        container.Connection.Close();
    }
}
