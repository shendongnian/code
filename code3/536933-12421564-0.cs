    public string QueryResult(string query)
            {
                  SQLiteDataAdapter ad;
                  string result = "";
                  SQLiteConnection sqlite = new SQLiteConnection("Data Source=/path/to/file.db");
                  try
                  {
                        SQLiteCommand cmd = new  SQLiteCommand();
                        sqlite.Open();  //Initiate connection to the db
                        cmd = sqlite.CreateCommand();
                        cmd.CommandText = query;  //set the passed query
                        result = cmd.ExecuteScalar().Tostring();
                  }
                  catch(SQLiteException ex)
                  {
                        //Add your exception code here.
                  }
                  sqlite.Close();
                  return dt;
      }
