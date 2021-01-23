    class ExtendedComboBox : ComboBox
    {
        public ExtendedComboBox()
        {
            SelectionChanged += OnSelectionChanged;
        }
        protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
        {
            ComboBoxItem cItem = element as ComboBoxItem;
            if (cItem != null)
            {
                cItem.Tapped += OnItemTapped;
            }
            base.PrepareContainerForItemOverride(element, item);
        }
        protected override void OnKeyUp(KeyRoutedEventArgs e)
        {
            // if the user hits the Enter or Space to select an item, then consider this a "reselect" operation
            if ((e.Key == Windows.System.VirtualKey.Space || e.Key == Windows.System.VirtualKey.Enter) && !isSelectionChanged)
            {
                // handle re-select logic here
            }
            isSelectionChanged = false;
            base.OnKeyUp(e);
        }
        // track whether or not the ComboBox has received a SelectionChanged notification
        // in cases where it has not yet we get a Tapped or KeyUp notification we will want to consider that a "re-select"
        bool isSelectionChanged = false;
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isSelectionChanged = true;
        }
        private void OnItemTapped(object sender, TappedRoutedEventArgs e)
        {
            if (!isSelectionChanged)
            {
                // indicates that an item was re-selected  - handle logic here
            }
            isSelectionChanged = false;
        }
    }
