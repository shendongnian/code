    public string FullAddress
    {
        get
        {
            return new List<string>
                { 
                    Address.ReferenceKey,
                    Address.PremisesName,
                    Address.PostTown,
                    Address.PostCode,
                    Address.County,
                    Address.Country
                }
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Aggregate((s1, s2) => s1 + "," + s2);
        }
    }
