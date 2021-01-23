    var subscriptions = service.ListSubscriptions(report.Path);
    foreach (var subscription in subscriptions)
    {
        ExtensionSettings settings;
        string description, status, eventType, matchData;
        ActiveState state;
        ParameterValue[] parameters;
        string user = service.GetSubscriptionProperties(subscription.SubscriptionID, out settings,
                                                        out description, out state, out status, out eventType,
                                                        out matchData, out parameters);
        if (matchData == scheduleId)
        {
            // Do what I need to do
        }
    }
