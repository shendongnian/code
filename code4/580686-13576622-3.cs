          private void btnProcessEntity_Click(object sender, RoutedEventArgs e)
          {
                    
             Button btn = sender as Button;
             MyEntity myEntity = btn.DataContext as MyEntity;
      
              // clicking a button in a row doesn't select the row, so select it.
             this.DataGrid1.SelectedItem = myEntity;  
             MessageBox.Show("Will Process: " + myEntity.name);
                    
              ...
           }
