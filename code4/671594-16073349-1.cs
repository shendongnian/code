    public bool AllSet
    {
        get
        {
            return !(Departments.Any(i => i.Active == false && i.IsDeleted == false));
        }
    }
