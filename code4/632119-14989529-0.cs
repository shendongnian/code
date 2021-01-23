    var queryable = new List<dynamic>();
    foreach(var entity in IList<Entity>)
    {
        dynamic companyProfile = Convert.ChangeType(entity, Type.GetType(typeString));
        if (companyProfile.CompanyProfileId == "something")
            queryable.Add(companyProfile);
        // Do Stuff
    }
    // Do Stuff
