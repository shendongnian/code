    [Browsable(false)] //Because we use the CreatorUsernameProperty to do this.
    public virtual User Creator { get; set; }
    
    [DisplayName("Creator")] //shows like this in the grid
    public string CreatorUsername => Creator?.Username;
