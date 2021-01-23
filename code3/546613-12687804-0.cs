    private static void RemoveDuplicates(DataTable tbl,
                                                 DataColumn[] keyColumns)
            {
                  int rowNdx = 0;
                  while(rowNdx < tbl.Rows.Count-1)
                  {
                        DataRow[] dups = FindDups(tbl, rowNdx, keyColumns);
                        if(dups.Length>0)
                        {
                              foreach(DataRow dup in dups)
                              {
                                    tbl.Rows.Remove(dup);
                              }
                        }
                        else
                        {
                              rowNdx++;
                        }
                  }
            }
 
            private static DataRow[] FindDups(DataTable tbl,
                                              int sourceNdx,
                                              DataColumn[] keyColumns)
            {
                  ArrayList retVal = new ArrayList();
 
                  DataRow sourceRow = tbl.Rows[sourceNdx];
                  for(int i=sourceNdx + 1; i<tbl.Rows.Count; i++)
                  {
                        DataRow targetRow = tbl.Rows[i];
                        if(IsDup(sourceRow, targetRow, keyColumns))
                        {
                              retVal.Add(targetRow);
                        }
                  }
                  return (DataRow[]) retVal.ToArray(typeof(DataRow));
            }
 
            private static bool IsDup(DataRow sourceRow,
                                      DataRow targetRow,
                                      DataColumn[] keyColumns)
            {
                  bool retVal = true;
                  foreach(DataColumn column in keyColumns)
                  {
                        retVal = retVal && sourceRow[column].Equals(targetRow[column]);
                        if(!retVal) break;
                  }
                  return retVal;
            }
