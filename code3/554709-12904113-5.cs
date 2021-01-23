    var accountsDict = data.Accounts.ToDictionary(a => a.Acct_CID);
    foreach (var incident in data.Incidents)
    {
        Account a;
        if (accountsDict.TryGetValue(incident.CustomerID, out a)
        {
            Tasks t = new Tasks();
            t.creator_id = a.ID;
            ...
        }
    }
    data.SaveChanges();
