    public partial class AddDataAnnotationsMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false,defaultValue:"MyTitle"));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false,defaultValue:"Genre"));
            AlterColumn("dbo.Movies", "Rating", c => c.String(maxLength: 5));
            AlterColumn("dbo.Movies", "Director", c => c.String(nullable: false,defaultValue:"Director"));
    
        }
    
        public override void Down()
        {       
            AlterColumn("dbo.Movies", "Director", c => c.String());
            AlterColumn("dbo.Movies", "Rating", c => c.String());
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());       
        }
    }
