    if (e.Result.Count == 0 && Utility.IsPostalCode(((GeocodeQuery)e.UserState).SearchTerm))
    {
        if (Geocode != null && Geocode.IsBusy)
            Geocode.CancelAsync();
    
        GetStringLocation(((GeocodeQuery)e.UserState).SearchTerm.Substring(0, 3));
    }
