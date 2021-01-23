        private void DockingManager_OnLoaded(object sender, RoutedEventArgs e)
        {
            OutputAnchorable.ToggleAutoHide();
            // You might want to do this to get a reasonable height
            var root = (LayoutAnchorablePane)OutputAnchorable.Parent;
            root.DockHeight = new GridLength(100);
        }
