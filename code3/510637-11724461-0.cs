    dataGridColumn Visibility="Visible"/>
    dataGridColumn Visibility="Collapsed"/>
    private void cbHideColumn_Changed(object sender, RoutedEventArgs e)
       {
         CheckBox cb = sender as CheckBox;
         if (this.dataGrid1 != null)
           {
             if (cb.IsChecked == true)
                this.dataGrid1.Columns[0].Visibility = Visibility.Collapsed;
             else if (cb.IsChecked == false)
                this.dataGrid1.Columns[0].Visibility = Visibility.Visible;
           }
       }
