    private DataTable Transpose(DataTable dt)
    {
        DataTable dtNew = new DataTable();
    
        //adding columns    
        for(int i=0; i<=dt.Rows.Count; i++)
        {
           dtNew.Columns.Add(i.ToString());
        }
 
        //Changing Column Captions: 
        dtNew.Columns[0].ColumnName = " ";
         for(int i=0; i<dt.Rows.Count; i++) 
         {
          //For dateTime columns use like below
           dtNew.Columns[i+1].ColumnName = Convert.ToDateTime(dt.Rows[i].ItemArray[0].ToString()).ToString("MM/dd/yyyy");
          //Else just assign the ItermArry[0] to the columnName prooperty
         }
            
        //Adding Row Data
        for(int k=1; k<dt.Columns.Count; k++)
        {
            DataRow r = dtNew.NewRow();
            r[0] = dt.Columns[k].ToString(); 
            for(int j=1; j<=dt.Rows.Count; j++)
            r[j] = dt.Rows[j-1][k];  
            dtNew.Rows.Add(r);
        }
            
     return dtNew;
    }
