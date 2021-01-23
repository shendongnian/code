     private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ButtonContextMenu.StaysOpen = true;
            (sender as MenuItem).ContextMenu.IsOpen = true;
        }
