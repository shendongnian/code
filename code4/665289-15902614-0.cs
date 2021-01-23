    [Table("TBL_UserProfile")]
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string eMail { get; set; }
        public virtual ICollection<UserVariant> Variants { get; set; }
    }
    
    [Table("TBL_UserVariant")]
    public class UserVariant
    {
        [Key]
        public int VarId { get; set; }
        public UserProfile User { get; set; }
        public string Value { get; set; }
    }
