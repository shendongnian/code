    SQLiteConnection source = new SQLiteConnection("Data Source=c:\\test.db");
    source.Open();
    
    using (SQLiteConnection destination = new SQLiteConnection(
      "Data Source=:memory:"))
    {
      destination.Open();				
      
      // copy db file to memory
      source.BackupDatabase(destination, "main", "main",-1, null, 0);
      source.Close();
      
      // insert, select ,...        
      using (SQLiteCommand command = new SQLiteCommand())
      {
        command.CommandText =
          "INSERT INTO t1 (x) VALUES('some new value');";
    
        command.Connection = destination;
        command.ExecuteNonQuery();
      }				
      
      source = new SQLiteConnection("Data Source=c:\\test.db");
      source.Open();
      
      // save memory db to file
      destination.BackupDatabase(source, "main", "main",-1, null, 0);
      source.Close();				
    }
