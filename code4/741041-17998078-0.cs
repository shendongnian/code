    private int LocateNextEntryForPersonAtXDateTime(string personName, string targetDateTime)
    {
      for (int i = 1; i <= csvGridView.Rows; i++)
      {
         if (csvGridView.Rows[i][0].Value.ToString().ToLower() == personName.ToLower()
           && Convert.ToDateTime(csvGridView.Rows[i][1].Value) >= targetDateTime)
             return i; // this is the row for the next entry when the person leaves
      }
    
      return -1; // not found
    }
