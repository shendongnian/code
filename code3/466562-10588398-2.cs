    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(c => c.Id)
                .GeneratedBy.HiLo("100");
            Map(c => c.FirstName);
            Map(c => c.LastName);
            HasMany(c => c.Roles)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(c => c.Id)
                .GeneratedBy.HiLo("100");
            DiscriminateSubClassesOnColumn<string>("RoleName");
            References(c => c.Person);
        }
    }
    public class UserMap : SubclassMap<User>
    {
        public UserMap()
        {
            DiscriminatorValue("User");
            Join("User", joined =>
                             {
                                 joined.Map(c => c.LoginName);
                                 joined.Map(c => c.Password);
                             });
        }
    }
