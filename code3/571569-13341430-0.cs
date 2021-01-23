      for (int row = 0; row < xlRange.Rows.Count; row++)
        {
          DataRow dataRow = null;
          if (row != 0) DataRow dataRow = excelTb.NewRow();
    
          for (int col = 1; j <= xlRange.Columns.Count; col++)
             {
               if (row == 0) //Headers
               {
                  excelTb.Columns.Add(xlRange.Cells[row,col].Value2.ToString());
               }
               else //Data rows
               {   
                  dataRow[col] = xlRange.Cells[row,col].Value2.ToString();
             
                }
             }
           }
        }
