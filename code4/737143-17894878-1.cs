    private void ItemContainerGeneratorStatusChanged(object sender, EventArgs e)
    {
        if (itemsControl.ItemContainerGenerator.Status
            == GeneratorStatus.ContainersGenerated)
        {
            var containers = itemsControl.Items.Cast<object>().Select(
                item => itemsControl.ItemContainerGenerator
                        .ContainerFromItem(item) as ContentPresenter);
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
        Trace.TraceInformation("{0}", VisualTreeHelper.GetChild(element, 0));
    }
