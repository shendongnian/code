    private void OnFindItem(object sender, RoutedEventArgs e)
        {
            ListViewItem output = e.Source as ListViewItem;
            if (output != null)
            {
                DataRowView rowView = output.Content as DataRowView;
                if (rowView != null)
                {
                    //More code here.
                }
             }
         }
