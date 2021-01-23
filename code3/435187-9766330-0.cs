    public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public LocationConfiguration()
            {
                HasKey(a => a.Id);
                HasMany(user => user.OfficeUsers).WithOptional(officeuser => officeuser.User).
                   HasForeignKey(officeuser => officeuser.UserId);
            }
        }
