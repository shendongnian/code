    public partial class editUserDTO : DbMigration
    {
        public override void Up()
        {
            string script =
            @"
            CREATE VIEW dbo.UserDTO
            AS SELECT p.PersonId AS UserId, p.FirstName, p.LastName, u.UserName
            FROM dbo.Users u
            INNER JOIN dbo.People p ON u.PersonId = p.PersonId";
            BloggingContext ctx = new BloggingContext();
            ctx.Database.ExecuteSqlCommand(script);
        }
        public override void Down()
        {
            BloggingContext ctx = new BloggingContext();
            ctx.Database.ExecuteSqlCommand("DROP VIEW dbo.UserDTO");
        }
    }
