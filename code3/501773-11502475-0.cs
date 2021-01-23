      for (int i = 0; i < gv.Rows.Count; i++)
            {
                valueCount=0;
                for (int j = 1; j < gv.Columns.Count; j++)
                {
                  if (gv.Rows[i][j].ToString()!='')
                      valueCount++;
                }
                 gv.Rows[i][0]=valueCount;  
            } 
   
