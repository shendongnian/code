    public bool AllSet
    {
        get
        {
            return !(Departments.Count(i => i.Active == false && i.IsDeleted == false) > 0);
        }
    }
