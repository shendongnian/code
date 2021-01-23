    work1.DoWork += doWork;
    work2.DoWork += doWork;
    work1.RunWorkerAsync(true);
    work2.RunWorkerAsync(false);
    
    private void doWork(s, e)
    {
      var kvp = new KeyValuePair<bool, bool>;
      kvp.Key = e.Argument as bool;
      ...
      using (Connection = new SqlConnection((string)e.Argument))
      {
        Connection.Open();
      }
      kvp.Value = true;
      ...
      e.Result = kvp
    };
