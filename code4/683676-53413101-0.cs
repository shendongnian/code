    private void FlipView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        FlipView fv = sender as FlipView;
        if (fv.SelectedItem == null) return;
        var item = fv.ItemContainerGenerator.ContainerFromItem(fv.SelectedItem);
        if (item == null)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var itemSecondTime = fv.ItemContainerGenerator.ContainerFromItem(fv.SelectedItem);
                    if (itemSecondTime == null)
                    {
                        throw new InvalidOperationException("no item.  Why????");
                    }
                });
        }
    }
