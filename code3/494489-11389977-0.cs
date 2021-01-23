    public partial class VoteTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("Votes", "Time", c => c.DateTime(nullable:false, defaultValue:DateTime.UtcNow));
        }
        
        public override void Down()
        {
            DropColumn("Votes", "Time");
        }
    }
