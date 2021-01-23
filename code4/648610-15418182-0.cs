    foreach (DataGridViewColumn col in grd1.Columns)
         {
             string myCol = col.Name;
             int myColLength = col.Name.Length;
             string myColMonth = myCol.Substring(myColLength - 2);
             int myColMonthInt = 0;
             if (int.TryParse(myColMonth, out myColMonthInt)) 
             {  
                 if (myColMonthInt <= myMostRecentActualMonth)
                 {
                     col.ReadOnly = true;
                 }
                 else
                 {
                     col.ReadOnly = false;
                 }
             } 
             else 
             {
                 // what do you want to do is last two chars can't be converted to int?
                 col.ReadOnly = true;
             }
         }        
