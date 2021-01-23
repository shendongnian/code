    namespace MyAttachedProperties
    {
        public class SelectingItemAttachedProperty
        {
            public static readonly DependencyProperty SelectingItemProperty = DependencyProperty.RegisterAttached(
                "SelectingItem",
                typeof(MySelectionType),
                typeof(SelectingItemAttachedProperty),
                new PropertyMetadata(default(MySelectionType), OnSelectingItemChanged));
            public static MySelectionType GetSelectingItem(DependencyObject target)
            {
                return (MySelectionType)target.GetValue(SelectingItemProperty);
            }
            public static void SetSelectingItem(DependencyObject target, MySelectionType value)
            {
                target.SetValue(SelectingItemProperty, value);
            }
            static void OnSelectingItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                var grid = sender as DataGrid;
                if (grid == null || grid.SelectedItem == null)
                    return;
                grid.Dispatcher.InvokeAsync(() => 
                {
                    grid.UpdateLayout();
                    grid.ScrollIntoView(grid.SelectedItem, null);
                });
            }
        }
    }
