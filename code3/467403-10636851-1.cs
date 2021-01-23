    private void MultiButton_Click(object sender, RoutedEventArgs e)
    {
       object dataContext = ((FrameworkElement)sender).DataContext;
       foreach (DataGridColumn col in dataGrid1.Columns)
       {
           if (col.Header.ToString() == dataContext.ToString())
           {
               col.Visibility = Visibility.Hidden;
           }
       }
    }
