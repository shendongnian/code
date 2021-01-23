    public IEnumerable<Organisation> Organisations
    {
        get 
        { 
            return PersonOrganisationRoles
                .Distinct()
                .ToList();
        }
    }
