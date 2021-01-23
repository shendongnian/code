    public class UserGroupsConfiguration : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupsConfiguration()
        {
            // Define a composite key
            HasKey(a => new { a.UserId, a.GroupId });
            // User has many Groups
            HasRequired(a => a.User)
                .WithMany(s => s.UserGroups)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);
            // Group has many Users
            HasRequired(a => a.Group)
                .WithMany(p => p.UserGroups)
                .HasForeignKey(a => a.GroupId)
                .WillCascadeOnDelete(false);
        }
    }
