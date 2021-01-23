    ...
    Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        LoadingState = LoadingState.COMPLETED;
        FeedLinks = Utils.GetLinksFromFeed(HttpUtility.HtmlDecode(e.Result));
        RaisePropertyChanged("FeedLinks");
        RaisePropertyChanged("LoadingState");
    });
