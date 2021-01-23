    public class UserConfiguration : EntityTypeConfiguration<VDE.User> {
        public UserConfiguration()
            : base() {
            ToTable("Users", "dbo");
            Property(u => u.EMail).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(u => u.Login).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);
            Property(u => u.Password).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(u => u.Description).HasColumnType("nvarchar").HasMaxLength(200);
            Property(u => u.LastConnectionDate).HasColumnType("datetime2");
            HasMany(u => u.Members).WithMany().Map(m => m.MapLeftKey("UserId").MapRightKey("MemberId").ToTable("UserMembers"));
        }
    }
