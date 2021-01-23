        [Table("TBL_UserProfile")]
        public class UserProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public string eMail { get; set; }
            public virtual ICollection<UserVariant> UserVariants { get; set; }
        }
