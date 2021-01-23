    public string GetCallingCode(Guid countryId)
    {
        var country = GetCountry(countryId);
        country.IsValid(); //throws if the country is not defined
        
        switch (country)
        {
            case Country.UnitedStates:
                return "1";
                break;
            case Country.Mexico:
                return "52";
                break;
        }
    }
