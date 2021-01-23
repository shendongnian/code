    foreach (DataRow row in dt.Rows)
        {
            for (int c = 0; c < dt.Columns.Count; c++) // c is column index
            {       
              double oldVal = Convert.ToDouble(row[c]);    
            
              double newVal = oldVal * -1;
                        
              row[c] = newVal;    
           
              this.Text = row[c].ToString();     
           }
    }
