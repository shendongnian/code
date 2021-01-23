    private void ellipseButton_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        button.ContextMenu.ItemsSource = JobPricingViewModel.SelectableDescriptions;
        if (button != null) button.ContextMenu.IsEnabled = true;
        var placementTarget = sender as Button;
        if (placementTarget != null) placementTarget.ContextMenu.PlacementTarget = placementTarget;
        var button1 = sender as Button;
        if (button1 != null)
            button1.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
        var button2 = sender as Button;
        if (button2 != null) button2.ContextMenu.IsOpen = true;
    }
