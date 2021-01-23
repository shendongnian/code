         private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (this.DataGrid1.SelectedItem == null)
                    return;
    
                MyEntity myEntity = (MyEntity)this.DataGrid1.SelectedItem;
       
                // at this point you have the (updated) data the row is bound to.
               MessageBox.Show("You Selected: " + myEntity.name);
               ...
