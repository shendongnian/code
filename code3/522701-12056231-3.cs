     private void TreeViewItem_GotFocus(object sender, RoutedEventArgs e)
            {
                string test = ((sender as TreeViewItem).DataContext as CanvasTemplate).Name;
                string Width = ((sender as TreeViewItem).DataContext as CanvasTemplate).Width+"";
               
            }
             
