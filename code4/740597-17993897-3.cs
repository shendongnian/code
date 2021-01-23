                if (InvokeRequired)
                         {
                     Invoke(new UpdateDelegate(
                      delegate
                      {
                           int rowcount = dg.Rows.Count;
                        for (b = 0; b < rowcount; b++)
                          {
                             string temp= dg.Rows[b].Cells[0].Value.ToString();
                             temp_List.Add(type1);
                          }
                       })
                       );
                     } 
