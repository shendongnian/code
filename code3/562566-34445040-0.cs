    namespace MyProject.Model.Migrations
    {
        using System;
        using System.Data.Entity.Migrations;
        
        public partial class RenameMyColumn : DbMigration
        {
            public override void Up()
            {
                // Remove the following auto-generated lines
                AddColumn("dbo.MyTable", "NewColumn", c => c.String(nullable: false, maxLength: 50));
                DropColumn("dbo.MyTable", "OldColumn");
                // Add
                RenameColumn("dbo.MyTable", "OldColumn", "NewColumn");
            }
            
            public override void Down()
            {
                // Remove the following auto-generated lines
                AddColumn("dbo.MyTable", "OldColumn", c => c.String(nullable: false, maxLength: 50));
                DropColumn("dbo.MyTable", "NewColumn");
                // Add
                RenameColumn("dbo.MyTable", "NewColumn", "OldColumn");
            }
        }
    }
