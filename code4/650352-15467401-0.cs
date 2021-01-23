    Task.Factory.StartNew
    (
        () =>
        {
            if (BfScrapper.Instance.CanStart)
                BfScrapper.Instance.StartTask(brwser);
        },
        CancellationToken.None,
        TaskCreationOptions.None,
        TaskScheduler.FromCurrentSynchronizationContext()
    );
