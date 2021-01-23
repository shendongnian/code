    public partial class ChangePrimaryKey : DbMigration
    {
        public override void Up()
        {
            Sql(@"exec sp_rename 'SchemaName.TableName.IndexName', 'New_IndexName', 'INDEX'");
        }
        
        public override void Down()
        {
            Sql(@"exec sp_rename 'SchemaName.TableName.New_IndexName', 'Old_IndexName', 'INDEX'");
        }
    }
