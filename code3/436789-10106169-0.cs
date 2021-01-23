    ResourceManager.Current.DefaultContext.QualifierValues.MapChanged += async (s, m) => 
    {
        // Reload the page
        await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            this.Frame.Navigate(this.GetType());
        });
    };
