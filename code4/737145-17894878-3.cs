    private void ItemContainerGeneratorStatusChanged(object sender, EventArgs e)
    {
        if (itemsControl.ItemContainerGenerator.Status
            == GeneratorStatus.ContainersGenerated)
        {
            var containers = itemsControl.Items.Cast<object>().Select(
                item => (FrameworkElement)itemsControl
                    .ItemContainerGenerator.ContainerFromItem(item));
            foreach (var container in containers)
            {
                container.Loaded += ItemContainerLoaded;
            }
        }
    }
    private void ItemContainerLoaded(object sender, RoutedEventArgs e)
    {
        var element = (FrameworkElement)sender;
        element.Loaded -= ItemContainerLoaded;
        var grid = VisualTreeHelper.GetChild(element, 0) as Grid;
        ...
    }
