        private void seznamSporocil_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBox = sender as ListBox;
            var item = listBox.SelectedItem as ListBoxItem;
            
            var newWindow = new Window1();
            newWindow.Title = item.Content.ToString();
            newWindow.Show();
        }
