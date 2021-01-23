    <ListBox MouseDoubleClick="ListBox_MouseDoubleClick">
    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var chk = FindParentControl<CheckBox>(e.OriginalSource as DependencyObject);
            if (chk != null)
            {
                ((CheckBox)chk).Content = "Content Changed";
            }
        }
    private DependencyObject FindParentControl<T>(DependencyObject control)
        {
            if (control == null)
                return null;
            DependencyObject parent = VisualTreeHelper.GetParent(control);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent;
        }
