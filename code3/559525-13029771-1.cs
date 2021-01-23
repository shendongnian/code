    public abstract class UserMapping: ClassMap<User>
    {
        protected UserMapping()
        {
            Table("Users");
            Map(x => x.Username).Column("Username").Length(20).Not.Nullable().Unique();
            Map(x => x.Password).Column("Password").Length(20).Not.Nullable();
            Map(x => x.Email).Column("Email").Length(50).Not.Nullable();
            //This line was missing
            HasMany<UserInRole>(Reveal.Member<User>("Roles")).
                Table("UsersInRoles").
                KeyColumn("UserId").
                Inverse().
                Cascade.Delete();
        }
    }
