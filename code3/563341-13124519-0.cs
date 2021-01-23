    var task = Task.Factory
        .StartNew<List<NewTwitterStatus>>(() => GetTweets(securityKeys), TaskCreationOptions.LongRunning)
        .ContinueWith<List<NewTwitterStatus>>(t =>
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() =>
                {
                    var result = t.Result;
                    RecentTweetList.ItemsSource = result;
                    Visibility = result.Any() ? Visibility.Visible : Visibility.Hidden;
                }));
        },
        CancellationToken.None,
        TaskContinuationOptions.None);
