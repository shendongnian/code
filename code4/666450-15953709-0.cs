    public PersonMap()
    {
        Id(x => x.ID).GeneratedBy.Identity();
        Map(x => x.FirstName).Not.Nullable().Length(100);
        Map(x => x.LastName).Not.Nullable().Length(100);
        Map(x => x.IsValid);
    }
