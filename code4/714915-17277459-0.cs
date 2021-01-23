    public static class ListBoxAttachedProperties
        {
            public static readonly DependencyProperty DisableUnselectLast = 
                DependencyProperty.RegisterAttached(
                "DisableUnselectLast", typeof(bool), typeof(ListBox),
                new PropertyMetadata(false, DisableUnselectLastChangedCallback));
    
            public static bool GetDisableUnselectLast(DependencyObject d)
            {
                return (bool)d.GetValue(DisableUnselectLast);
            }
    
            public static void SetDisableUnselectLast(DependencyObject d, bool value)
            {
                d.SetValue(DisableUnselectLast, value);
            }
    
            private static void DisableUnselectLastChangedCallback(
                DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (!(d is ListBox))
                {
                    return;
                }
    
                var selector = d as ListBox;
                bool oldValue = (bool)e.OldValue;
                bool newValue = (bool)e.NewValue;
    
                if (oldValue == newValue)
                {
                    return;
                }
    
                if (oldValue == false)
                {
                    selector.PreviewMouseLeftButtonDown += listBox_PreviewMouseLeftButtonDown;
                }
                else
                {
                    selector.PreviewMouseLeftButtonDown -= listBox_PreviewMouseLeftButtonDown;
                }
            }
    
            private static void listBox_PreviewMouseLeftButtonDown(
                object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                var listBox = sender as ListBox;
                if (listBox != null && listBox.SelectedItems.Count == 1)
                {
                    UIElement container = listBox.ItemContainerGenerator
                        .ContainerFromItem(listBox.SelectedItems[0]) as UIElement;
                        
                    if (container != null)
                    {
                        var pos = e.GetPosition(container);
                        var result = VisualTreeHelper.HitTest(container, pos);
                        if (result != null)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
