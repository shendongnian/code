    using Windows.UI.Core;
    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        while (true)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => MoveRect());
            Sleep(100);
        }
    }
