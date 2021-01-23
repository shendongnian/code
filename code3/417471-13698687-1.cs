    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual UserInfo Information{get;set;}
    }
    
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        internal UserConfiguration()
        {
            ToTable("Users");
    
            HasKey(x => x.Id);
    
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);
            Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(128);
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(128);        
        }
    }
    
    public class UserInfo
    {
        [ForeignKey("InfosUser")]
        [Key]
        public UserId {get;set;}
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual User InfosUser {get;set;}
    }
    
    internal class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        internal UserInfoConfiguration()
        {
            ToTable("Persons");
    
            Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(16);
            Property(x => x.MiddleName)
                .IsOptional()
                .HasMaxLength(16);
            Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(16);
            HasRequired(ui=>ui.InfosUser).WithOptional(u=>u.Information)
        }
    }
