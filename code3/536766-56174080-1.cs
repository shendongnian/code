    using System.Data.Entity.Migrations;
    
    public partial class some_migration : ExtendedDbMigration
    {
        public override void Up()
        {
            DoCommonTask("Up");
        }
    
        public override void Down()
        {
            UndoCommonTask("Down");
        }
    }
