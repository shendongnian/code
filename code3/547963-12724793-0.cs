    public string Address { get; set; }
    [StringLength(40)]
    public string City { get; set; }
    [StringLength(30)]
    public string State { get; set; }
    [StringLength(10)]
    [NotMapped]
    public string Zip { get; set; }
