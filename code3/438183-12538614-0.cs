    public class TestMigration : DbMigration, IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "TestMigration "; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "1"; }
        }
        public override void Up()
        {
            CreateTable("TestMigrationTable", t => new { Id = t.Int(identity: true, nullable: false), Name = t.String(nullable: true) });
        }
        public override void Down()
        {
            DropTable("TestMigrationTable");
        }
    }
