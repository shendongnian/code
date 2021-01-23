    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
              Table(@"Roles");
              Id(x => x.Id).GeneratedBy.Assigned();
              Map(x => x.Name).Column("Name");
              HasMany<User>(x => x.Users)
                .Inverse()
                .KeyColumns.Add("RoleId", mapping => mapping.Name("RoleId"));
        }
    }
