    public partial class RenameColumn : DbMigration
    {
        public override void Up()
        {
           Sql("update blah...");
        }
        public override void Down()
        {
          Sql("drop table bobby");
        }
