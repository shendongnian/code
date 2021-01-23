    foreach (var item in query)
    {
      var adPerson = new ADPerson
      {
        AdPersonId         = item.AdPersonId,
        SamAccountName     = item.SamAccountName,
        Description        = item.Description,
        DisplayName        = item.DisplayName,
        UserPrincipalName  = item.UserPrincipalName,
        Enabled            = item.Enabled,
        LastUpdated        = item.LastUpdated,
        OnlineAssetTag     = item.OnlineAssetTag,
        MsdnTypeId         = item.MsdnTypeId,
        MsdnSubscription   = item.MsdnTypeDescription,
      {
    }
