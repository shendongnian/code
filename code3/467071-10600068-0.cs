      using (SQLiteTransaction mytransaction = myconnection.BeginTransaction())
      {
        using (SQLiteCommand mycommand = new SQLiteCommand(myconnection))
        {
          SQLiteParameter myparam = new SQLiteParameter();
        
          mycommand.CommandText = "YOUR QUERY HERE";
          mycommand.Parameters.Add(myparam);
          
          foreach (CatItem CatItem in _knownFiless)
          {
            ...
            mycommand.ExecuteNonQuery();
          }
        }
        mytransaction.Commit();
      } 
