    [Key] 
    [ForeignKey("UserId")]
    public int JoggerId { get; set; }
    public string Pronation {get; set;}
    public virtual UserProfile UserId { get; set; }
