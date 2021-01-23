      [Key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public int UserId { get; set; }
      public string UserName { get; set; }
      // Navigation properties
      public virtual Jogger Jogger { get; set; }
