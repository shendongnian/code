    //Unchecked handler
     void menuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            foreach (Microsoft.Windows.Controls.DataGridColumn column in dataGrid1.Columns)
            {
               if (column.Header.ToString().Contains(item.Header.ToString()))
                {
                   column.Visibility = Visibility.Collapsed;
                    break;
                }
              
                
            }
        }
