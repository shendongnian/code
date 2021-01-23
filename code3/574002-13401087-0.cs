     for(int intCount = 0;intCount < dt.Rows.Count; intCount++)
     {
      for(int intSubCount = 0; intSubCount < dt.Columns.Count; intSubCount++)
       {
             dt.Rows[intCount][intSubCount] = yourValue; // or assign to something
       }
     }
