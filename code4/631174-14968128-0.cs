    [ForeignKey("Creator")]
    public int CreatorId { get; set; }
        
    [ForeignKey("Manager")]
    public int ManagerId { get; set; }
    [ForeignKey("Executor")]
    public int ExecutorId { get; set; }
    public virtual User Creator { get; set; }
    public virtual User Manager { get; set; }
    public virtual User Executor { get; set; }
