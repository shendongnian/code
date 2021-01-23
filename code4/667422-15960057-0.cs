    private void mnuDelete_Click(object sender, RoutedEventArgs e)
    {
        DatabaseIndex index = (DatabaseIndex)((MenuItem)sender).DataContext;
        if (index.Deleted)
        {
            index.Deleted = false;
            // code to undelete
        }
        else
        {
            index.Deleted = true;
            // code to delete
        }
    }
