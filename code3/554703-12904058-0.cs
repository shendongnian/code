    var joinedResult = data.Accounts.Join(data.Incidents, 
                                          a => a.Acct_CID, 
                                          i => i.CustomerID, 
                                          (a, i) => new { Account = a, Incident = i });
    foreach (var item in joinedResult)
    {
        Tasks t = new Tasks();
        t.creator_id = item.Account.ID;
        t.start_date = item.Incident.DateOpened;
        ........
    }
