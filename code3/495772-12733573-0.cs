    public User()
        {
        this.SecurityGroups.CollectionChanged += (sender, e) =>
            {
            if (e.Action == Add)
                {
                foreach (SecurityGroup AddedGroup in e.NewItems)
                AddSecurityGroup(AddedGroup);
                }
            if (e.Action == Remove)
                {
                foreach (SecurityGroup RemovedGroup in e.OldItems)
                RemoveSecurityGroup(RemovedGroup);
                }
            };
	    ..... rest of constructor
        }
    public void AddSecurityGroup(SecurityGroup secGroup)
        {
        LinkDescriptor descriptr = _ctx.GetLinkDescriptor(this, "SecurityGroups", secGroup);
        if (descriptr == null)
            _ctx.AddLink(this, "SecurityGroups", secGroup);
              
        else if (descriptr.State == EntityStates.Deleted)
            _ctx.DetachLink(this, "SecurityGroups", secGroup);
               
        }
    public void RemoveSecurityGroup (SecurityGroup secGroup)
        {
        LinkDescriptor descriptr = _ctx.GetLinkDescriptor(this, "SecurityGroups", secGroup);
        if (descriptr == null)
            {
            _ctx.AttachLink(this, "SecurityGroups", secGroup);
            _ctx.DeleteLink(this, "SecurityGroups", secGroup);
            }
        else if (descriptr.State == EntityStates.Added)
            _ctx.DetachLink(this, "SecurityGroups", secGroup);
              
        else
            _ctx.DeleteLink(this, "SecurityGroups", secGroup);
                          
        }
