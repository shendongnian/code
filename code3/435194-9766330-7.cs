    public class RoleConfiguration : EntityTypeConfiguration<Role>
        {
            public LocationConfiguration()
            {
                HasKey(a => a.RoleId);
                HasMany(role =>role.OfficeUsers).WithOptional(officeuser => officeuser.Role).
                   HasForeignKey(officeuser => officeuser.OfficeRoleId);
            }
        }
