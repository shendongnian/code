        //Primary AND Foreign key 1
    [Key]
     public int UserID {get; set;}
    [ForeignKey("UserID")]
    public virtual IEnumerable<UserProfile> users;
        
        //Primary AND Foreign key 2
    
    public int ProductID {get; set;}
    [ForeignKey("ProductID")]
    public virtual IEnumerable<Product> products;
