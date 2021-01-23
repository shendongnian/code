        public class UserProjectRole
        {
            [Key, Column (Order = 0)]
            public Guid UserProjectRoleID { get; set; }
    
        [Key, Column (Order = 1)]
        [ForeignKey("Project")]
        public Guid ProjectID { get; set; }
    
        [Required]
        public Project Project { get; set; }
    
        public Guid AppUserGuid { get; set; }
    
        // followed by a number of unrelated String fields.
     }
    
    public class Project: Base
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectID { get; set; }
    
        public virtual ICollection<UserProjectRole> UserRoles { get; set; }
    
        // followed by a number of unrelated String fields.
    
    }
    
        public class SiteContext : DbContext
    {
    
        public DbSet<Project> Projects { get; set; }
    
        public DbSet<UserProjectRole> UserProjectRoles { get; set; }
    }
