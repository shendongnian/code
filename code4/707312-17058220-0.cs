    for (int x = 0; x < results.Count; x++ ) //typecast x a get error to loop the results
    {
      TableRow tr = new TableRow();
      Table1.Rows.Add(tr);
      
      GetErrors value = results[x];
    
      TableCell tc = new TableCell();
      tc.Text = results[x].FWWDIR_ROW + results[x].FWWDIR_ERR_INVOICE + results[x].FWWDIR_ERR_ACCOUNT;
      tr.Cells.Add(tc);// = new TableCell();
    }
