    [ForeignKey("Article")]
    public int? ArticleId { ... }
    public virtual Article Article { get; set; }
    [ForeignKey("Event")]
    public int? EventId { get; set; }
    public virtual Event Event { get; set; }
