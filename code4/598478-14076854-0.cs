    IsInternetAllowed = false;
    DateTime dateOfInterest = datesToRestrict
        .FirstOrDefault(dt => dt.Date == DateTime.Now.Date);
    if (dateOfInterest != null)
    {
        if (timesToAllowDict.ContainsKey(DateTime.Now.Date))
        {
            List<Tuple<DateTime, DateTime>> lstAllowed = 
                timesToAllowDict[DateTime.Now.Date];
            IsInternetAllowed = lstAllowed  
                .FirstOrDefault(time => 
                    DateTime.Now.Time > time.Value1 &&
                    DateTime.Now.Time < time.Value2) != null;
        }
    }
    if (IsInternetAllowed)
        Enable(networkName);
    else
        Disable(networkName);
