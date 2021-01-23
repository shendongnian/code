    public IEnumerable<Office> GetOffices (string postCode)
    {
        var myOffices = _readOnlySession.All<Office> ()
            .GetMyOffices (_userSession)
            .ToList (); // Get all the offices you are interested in.
			
        IEnumerable<OfficePostCode> postCodeDistricts = _readOnlySession
            .All<OfficePostCode> ()
            .Where (x => x.Region.StartsWith (postCode, true, System.Globalization.CultureInfo.InvariantCulture))
            .ToList (); // A list of OfficePostCodes with the specified region.
        
        // Using the 3 parameter overload for StartsWith lets you specify a case invariant comparison,
        // which saves you from having to do .ToLower().
        yield return myOffices.Where (o => postCodeDistricts.Any (pcd => o.PostCodeID == pcd.PostCodeID));
    }
