    private async void FilterListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        progressRing.IsActive = true;
        try
        {
            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                filteredImage = await FilterMethod.imageBW(originalImage, filteredImage);
            }
        }
        catch
        {
            Debug.WriteLine("No items selected");
        }
        mainImage.Source = filteredImage;
        progressRing.IsActive = false;
    }
