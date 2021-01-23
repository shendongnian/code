    foreach (DataRow row in dt.Rows)
        {
            for (int c = 0; c < columns; c++) // c is column index
            {       
              double oldVal = Convert.ToDouble(row[c]);    
            
              double newVal = -oldVal;
                        
              row[c] = newVal;    
           
              this.Text = row[c].ToString();     
           }
        }
