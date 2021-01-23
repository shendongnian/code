     public class MyListView : ListView
        {
            protected override void OnPreviewMouseDown(System.Windows.Input.MouseButtonEventArgs e)
            {
                DependencyObject listViewItem = (DependencyObject)e.OriginalSource;
                while (listViewItem != null && !(listViewItem is ListViewItem))
                    listViewItem = VisualTreeHelper.GetParent(listViewItem);
    
                SelectedItem = ((ListViewItem)listViewItem).Content;
    
                base.OnPreviewMouseDown(e);
            }
        }
