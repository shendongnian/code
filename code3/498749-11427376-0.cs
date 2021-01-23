    foreach (var item in OriginalItems)
    {
        var copy = item;
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            CopyOfItems.Add(copy);
        });
        // I feel sooo sleepy
    }
