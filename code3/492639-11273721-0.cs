    namespace CodeFirstMembershipSharp
    {
        public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                context.Users.Add(new User{name = "Demo", password = "123456"});
                context.Roles.Add(New Role("Admin"));
            }
        }
    }
