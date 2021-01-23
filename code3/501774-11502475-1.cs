      for (int i = 0; i < gv.Rows.Count; i++)
            {
                valueCount=0;
                for (int j = 1; j < gv.Columns.Count; j++)
                {
                  if (gv.Rows[i].Cells[j].ToString()!='')
                      valueCount++;
                }
                 gv.Rows[i].Cells[0]=valueCount;  
            } 
   
