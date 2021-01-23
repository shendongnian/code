    var accountsLookup = data.Accounts.ToLookup(a => a.Acct_CID);
    Incidents[] Incidents = data.Incidents.ToArray();
    for (int i = 0; i < Incidents.Length; i++)
    {
        foreach (var a in accountsLookup[Incidents[i].CustomerID])
        {
            Tasks t = new Tasks();
            t.creator_id = a.ID;
            ...
        }
    }
    data.SaveChanges();
