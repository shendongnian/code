      using (var database = new Database("path\\to\\package.msi", DatabaseOpenMode.ReadOnly))
      {
        var table = database.Tables["someTableName"];
        foreach (var column in table.PrimaryKeys)
        {
          Console.WriteLine("The table {0} defines {1} as primary key", table.Name, column);
        }
      }
