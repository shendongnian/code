    public class ListViewExtras : DependencyObject
        {
            public static bool GetWillAlwaysSelect(DependencyObject obj)
            {
                return (bool)obj.GetValue(WillAlwaysSelectProperty);
            }
    
            public static void SetWillAlwaysSelect(DependencyObject obj, bool value)
            {
                obj.SetValue(WillAlwaysSelectProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for WillAlwaysSelect.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty WillAlwaysSelectProperty =
                DependencyProperty.RegisterAttached("WillAlwaysSelect", typeof(bool), typeof(ListViewExtras), new PropertyMetadata(false, new PropertyChangedCallback((s, e) =>
                {
                    ListView listView = s as ListView;
                    if (listView != null)
                    {
                        if ((bool)e.NewValue) listView.PreviewMouseDown += listView_PreviewMouseDown;
                        if (!(bool)e.NewValue && (bool)e.OldValue) listView.PreviewMouseDown -= listView_PreviewMouseDown;
                    }
                })));
    
            static void listView_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                ListView listView = sender as ListView;
                if (listView != null)
                {
                    DependencyObject listViewItem = (DependencyObject)e.OriginalSource;
                    while (listViewItem != null && !(listViewItem is ListViewItem))
                        listViewItem = VisualTreeHelper.GetParent(listViewItem);
                    listView.SelectedItem = ((ListViewItem)listViewItem).Content;
                }
            }
        }
