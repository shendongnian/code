    public class UserMap : ClassMap<User>
    {
       public UserMap()
        {
              Table(@"Users");
              Id(x => x.Id).GeneratedBy.Assigned();
              Map(x => x.FirstName);
              Map(x => x.RoleId);    
              References(x => x.Role)
                .Class<Role>()
                .Columns("RoleId");
        }
    }
