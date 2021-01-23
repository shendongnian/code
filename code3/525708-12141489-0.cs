      for (int y = 0; y <count; y++)
        {
        try
           {
       if(xlWorkSheet.Range["A" + (y + 2) + ""].Value.ToString() != "")
          {
         if (!(xlApp.CheckSpelling(xlWorkSheet.Range["A" + (y + 2) + ""].Value.ToString(), 
                 udict, 1033)))
               {
                  xlApp.Visible = false;
                  xlWorkSheet.Cells[y + 2, 2] = "chk";            
                     }
                  }
              }
         catch(Exception)
          {
           }
          }
