    public async void OnMyEvent(object sender, DeferredEventArgs e)
    {
        using (e.GetDeferral())
        {
            await DoSomethingAsync();
        }
    }
