                  // create an example datatable with duplicate rows
                  DataTable tbl = new DataTable();
 
                  tbl.Columns.Add("ColumnA");
                  tbl.Columns.Add("ColumnB");
                  tbl.Columns.Add("ColumnC");
                  for(int i = 0; i<10; i++)
                  {
                        DataRow nr = tbl.NewRow();
                        nr["ColumnA"] = "A" + i.ToString();
                        nr["ColumnB"] = "B" + i.ToString();
                        nr["ColumnC"] = "C" + i.ToString();
                        tbl.Rows.Add(nr);
                        // duplicate
                        nr = tbl.NewRow();
                        nr["ColumnA"] = "A" + i.ToString();
                        nr["ColumnB"] = "B" + i.ToString();
                        nr["ColumnC"] = "C" + i.ToString();
                        tbl.Rows.Add(nr);
                  }
 
                  PrintRows(tbl); // show table with duplicates
 
                  //Create an array of DataColumns to compare
                  //If these columns all match we consider the
                  //rows duplicate.
                  DataColumn[] keyColumns =
                              new DataColumn[]{tbl.Columns["ColumnA"],
                                               tbl.Columns["ColumnA"]};
 
                  //remove the duplicates
                  RemoveDuplicates(tbl, keyColumns);
