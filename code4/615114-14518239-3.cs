    public void Execute(params object[] parameters)
    {
        var matchingSubscriptions =
            _subscriptions.Where(x => x.CanExecuteForParameters(parameters);
        foreach(var subscription in matchingSubscriptions)
            subscription.Execute(parameters);
    }
