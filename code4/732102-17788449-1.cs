    var merges = new List.Merges();
    var groupingList = new MailChimp.Types.MCList<MailChimp.Types.List.Grouping>();
    var grouping = new MailChimp.Types.List.Grouping(myGroupId, new string[] { group1, group2 });
    groupingList.Add(grouping);
    merges["Groupings"] = groupingList;
    // You may find it practical to include the following options, at least while testing the groupings
    var options = new MailChimp.Types.List.SubscribeOptions();
    options.DoubleOptIn = false;
    options.ReplaceInterests = false;
    options.SendWelcome = false;
    
    mcapi.ListSubscribe(myMailChimpListId, email, merges, options);
