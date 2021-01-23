     foreach (string value in results[x])//fails here with Ienumerable error
                           {
                               
                               TableCell tc = new TableCell();
                               tc.Text = results[x].FWWDIR_ROW + results[x].FWWDIR_ERR_INVOICE    +                                         results[x].FWWDIR_ERR_ACCOUNT;
                               tr.Cells.Add(tc);// = new TableCell();
                           }
