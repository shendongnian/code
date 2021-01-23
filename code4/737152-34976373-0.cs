    public partial class NameOfMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubTable", "FKColumnName", "dbo.MainTable");
            DropIndex("dbo.SubTable", new[] { "FKColumnName" });
    
            AlterColumn("dbo.SubTable", "FKColumnName", c => c.Int(nullable: false));
    
            CreateIndex("dbo.SubTable", "FKColumnName");
            AddForeignKey("dbo.SubTable", "FKColumnName", "dbo.MainTable", "Id");
        }
    
        public override void Down()
        {
            DropForeignKey("dbo.SubTable", "FKColumnName", "dbo.MainTable");
            DropIndex("dbo.SubTable", new[] { "FKColumnName" });
    
            AlterColumn("dbo.SubTable", "FKColumnName", c => c.Int(nullable: true));
    
            CreateIndex("dbo.SubTable", "FKColumnName");
            AddForeignKey("dbo.SubTable", "FKColumnName", "dbo.MainTable", "Id");
        }
    }
