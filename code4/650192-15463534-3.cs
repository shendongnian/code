    public partial class Initial : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.Distances",
                c => new {
                    DistanceId = c.Guid(nullable: false),
                    MeetingId = c.Int(nullable: false),
                    Key = c.String(nullable: false, maxLength: 20),
                    Name = c.String(nullable: false, maxLength: 100),
                    Ordering = c.Short(nullable: false),
                    AllowMale = c.Boolean(nullable: false),
                    AllowFemale = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.DistanceId)
                .ForeignKey("dbo.Meetings", t => t.MeetingId, cascadeDelete: true)
                .Index(t => t.MeetingId)
                .Index(t => new { MeetingId = t.MeetingId, Ordering = t.Ordering });
        }
        public override void Down() {
            DropTable("dbo.Distances");
        }
    }
