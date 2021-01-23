        void menuItem_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
       
            List<string> menuList = new List<string>();
            menuList.Clear();
             foreach (Microsoft.Windows.Controls.DataGridColumn column in dataGrid1.Columns)
            {
               if (column.Header.ToString().Contains(item.Header.ToString()))
                {
                   column.Visibility = Visibility.Visible;
                    break;
                }
              
                
            }
          
        }
