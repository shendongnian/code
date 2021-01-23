    class User {
      // user properties...
      [ForeignKey("UserGroupID")]
      public virtual Group Group { get; set; }
    }
    class Group {
      // group properties...
      public virtual ICollection<User> Users { get;set; }
    }
