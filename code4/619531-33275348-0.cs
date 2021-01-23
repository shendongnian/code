    DataGVEmployee.RowStateChanged += new DataGridViewRowStateChangedEventHandler(DataGVEmployee_RowStateChanged);
    
     if (e.StateChanged == DataGridViewElementStates.Selected)
                {
                    e.Row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
                else
                {
                    e.Row.DefaultCellStyle.SelectionBackColor = Color.White;
                   
                }
