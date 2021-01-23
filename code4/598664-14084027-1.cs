      public partial class Window3 : Window
      {
        public Window3() {InitializeComponent();}
        double _currentWidth;
        double _currentHeight;
        private void MainTabControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TabItem currentItem = MainTabControl.SelectedItem as TabItem;
            FrameworkElement content = currentItem.Content as FrameworkElement;
            _currentWidth = content.ActualWidth;
            _currentHeight = content.ActualHeight;
        }
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem itemAdded = null;
            TabItem itemRemoved = null;
            if (e.AddedItems.Count > 0)
                itemAdded = e.AddedItems[0] as TabItem;
            if (e.RemovedItems.Count > 0)
                itemRemoved = e.RemovedItems[0] as TabItem;
            if (itemAdded != null && itemRemoved != null)
            {
                FrameworkElement content = itemAdded.Content as FrameworkElement;
                double newWidth = content.Width;
                double newHeight = content.Height;
                if (newWidth < _currentWidth)
                    content.Width = _currentWidth;
                if (newHeight < _currentHeight)
                    content.Height = _currentHeight;
            }
        }
    }
