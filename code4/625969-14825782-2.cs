    [Table("UserProfile")]
    public class UserProfile
    {
       [Key]
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public int UserId { get; set; }
       public string UserName { get; set; }
       public virtual ICollection<UsersInRole> UsersInRole { get; set; }
    }
