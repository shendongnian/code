    public new IQueryable<Assignee> Assignees 
    {
        get
        {
            return base.Assignees.Where(z => z.IsActive == true);
        }
    }
