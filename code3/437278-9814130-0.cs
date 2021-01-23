    [Key]
    public int CompletedId { get; set; }
    public int OldStepId { get; set; }
    public int NewStepId { get; set; }
    public string Name { get; set; }
        
    [ForeignKey("OldStepId")]
    public virtual Step OldStep { get; set; }
    [ForeignKey("NewStepId")]
    public virtual Step NewStep { get; set; }
