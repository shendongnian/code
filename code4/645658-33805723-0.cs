     [Table("ls_roles")]
    public class Role
    {
        [Required]
        [Key]
        public int RoleID { get; set; }
        [Required]
        public String BarColor { get; set; }
        public virtual ICollection<ScheduleEmployee> Employees { get; set; }
    }
    [Table("ls_ScheduleEmployee")]
    public class ScheduleEmployee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        
        public virtual  Role Role { get; set; }
    }
