    public override DbSet<Assignee> Assignees 
    {
        get
        {
            return base.Assignees.Where(z => z.IsActive == true);
        }
        set; 
    }
