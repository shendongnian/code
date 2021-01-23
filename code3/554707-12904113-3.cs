    var accountsDict = data.Accounts.ToDictionary(a => a.Acct_CID);
    Incidents[] Incidents = data.Incidents.ToArray();
    for (int i = 0; i < Incidents.Length; i++)
    {
        Account a;
        if (accountsDict.TryGetValue(Incidents[i].CustomerID, out a)
        {
            Tasks t = new Tasks();
            t.creator_id = a.ID;
            ...
        }
    }
    data.SaveChanges();
