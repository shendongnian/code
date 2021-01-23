        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = ((System.Windows.Controls.Button)sender);
            var clickedItem = (DataItem)button.DataContext;
            MessageBox.Show(clickedItem.Name);
        }
