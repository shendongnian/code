    private void LayoutRoot_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Delete)
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to delete this record ?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        view.DeleteRow(view.FocusedRowHandle);
                        e.Handled = true;
                     }
             
