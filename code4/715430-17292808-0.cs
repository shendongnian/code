        searcher.PropertiesToLoad.Add("sAMAccountName");  // and add any others you need
        try
        {
           foreach (SearchResult result in searcher.FindAll())
           {
              TableRow tblRow = new TableRow();
              TableCell tblcell_Username = new TableCell();
              tblcell_Username.Text = result.Properties["SAMAccountName"].ToString();
