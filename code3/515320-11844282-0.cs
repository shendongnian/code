    public string FullAddress
    {
        get
        {
            return new List<string>
                { 
                    ReferenceKey,
                    PremisesName,
                    Country,
                    County,
                    Postcode
                }
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Aggregate((s1, s2) => s1 + "," + s2);
        }
    }
