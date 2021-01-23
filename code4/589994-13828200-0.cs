    // <set>
    public virtual ISet<Child> Children { get; set; }    
    HasMany(x => x.Children); // <set />
    // <bag>
    public virtual IList<Child> Children { get; set; }    
    HasMany(x => x.Children); // <bag />
    // <list>
    public virtual IList<Child> Children { get; set; }    
    HasMany(x => x.Children).AsList(...; // <list />
