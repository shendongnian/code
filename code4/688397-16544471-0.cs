    IDictionary<string, object> dictionary = myObject;
    foreach (var activity in members.ActivityList)
    {
        dictionary[activity.ActivityName] = activity.Minutes;
    }
