     [ForeignKey("UserCreator")]
     public Guid UserCreatorId { get; set; }  
    
      public User UserCreator{ get; set; }  
     [InverseProperty("Events")]
    public ICollection<User> Users { get; set; }
