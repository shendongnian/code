    [Column("User_Status")]
    public int UserStatusAsInt { get; set; }
    
    [NotMapped]
    public UserStatus UserStatus
    {
      get { return (UserStatus) this.UserStatusAsInt; }
      set { this.UserStatusAsInt = (int)value; }
    }
