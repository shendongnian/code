    This worked for me.
    
    private void setrowcolor()
       {
           bool checkSelected = false;
           foreach (DataGridViewRow row in gridgencsv.Rows)
           {
              checkSelected =Convert.ToBoolean(row.Cells["select_check"].Value);
                if (checkSelected == true)
                  {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.CadetBlue;
                  }
                else
                  {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                  }
                
            }
       }
