    public async SomeMethod()
    {
        await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
            {
                 //   Your code here...
            });
    }
