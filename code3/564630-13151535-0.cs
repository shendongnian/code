    [Table("tablename...")]
    public class Branch
    {
        public Branch()
        {
            Users = new List<User>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
    
    [Table("tablename...")]
    public class User
    {
        [Key]
        public int Id {get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("ParentBranch")]
        public int? ParentBranchId { get; set; } // Is this possible?
        public virtual Branch ParentBranch { get; set; } // ???
    }
