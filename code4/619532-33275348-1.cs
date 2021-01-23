     DataGVEmployee.RowStateChanged += new DataGridViewRowStateChangedEventHandler(DataGVEmployee_RowStateChanged);
      
        void DataGVEmployee_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
            {
         if (e.StateChanged == DataGridViewElementStates.Selected)
                    {
                        e.Row.DefaultCellStyle.SelectionBackColor = Color.Red;
                    }
                    else
                    {
                        e.Row.DefaultCellStyle.SelectionBackColor = Color.White;
                       
                    }
    }
