        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }
Then I created another Sql migration, to alter value to default:
    public partial class AlterTableUpdatedAtDefault : DbMigration
    {
        public override void Up()
        {
            Sql(@"ALTER TABLE dbo.[Table]
                  ADD CONSTRAINT DF_Table_UpdatedAt
                  DEFAULT getdate() FOR UpdatedAt");
        }
        
        public override void Down()
        {
            Sql(@"ALTER TABLE dbo.[Table]
                  drop CONSTRAINT DF_Table_UpdatedAt");
        }
    }
