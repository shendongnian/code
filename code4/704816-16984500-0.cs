     private void YourGridName_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
            {               
              string fc = null;                   
              foreach (var item in e.AddedCells)
               {                        
                fc =((System.Data.DataRowView(item.Item)).Row.ItemArray[0].ToString();
               }
             }
