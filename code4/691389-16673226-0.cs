    await MyDatabaseManager.Connection.RunInTransactionAsync((SQLiteConnection connection) =>
    {
      foreach (Hotel _hotel in listUpdates)
      {
        result = connection.Update(_hotel);
        if (result == 0)
        {
          connection.Insert(_hotel);
        }
      }
    });
