    public bool FieldExists(OleDbConnection connection, string tabName, string fieldName)
    {
      var adapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", tabName), connection);
      var ds = new DataSet();
      adapter.Fill(ds, tabName);
    
      foreach (var item in ds.Tables[tabName].Rows[0].ItemArray)
      {
        if (item.ToString() == fieldName)
          return true;
      }
      return false;
    }
