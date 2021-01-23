    public partial class AddAbsencesTypesAndCategories : DbMigration
        {
            public override void Up()
            {
                CreateTable(
                    "pvw_AbsenceType",
                    c => new
                        {
                            Id = c.Int(nullable: false, identity: true),
                            Name = c.String(nullable: false),
                            CountAsVacation = c.Boolean(nullable: false),
                            IsIncremental = c.Boolean(nullable: false),
                        })
                    .PrimaryKey(t => t.Id);
                
              .....
                
                AddColumn("pvw_Absence", "CategoryId", c => c.Int(nullable: false));
    						AddForeignKey("pvw_Absence", "StatusId", "pvw_AbsenceStatusType", "Id");
                AddForeignKey("pvw_Absence", "CategoryId", "pvw_AbsenceType", "Id");
                CreateIndex("pvw_Absence", "StatusId");
                CreateIndex("pvw_Absence", "CategoryId");
                DropColumn("pvw_Absence", "MainCategoryId");
                DropColumn("pvw_Absence", "SubCategoryId");
               ......
                Sql(@"
    										SET IDENTITY_INSERT [dbo].[pvw_AbsenceStatusType] ON
                        INSERT pvw_AbsenceStatusType (Id, Name) VALUES (1, N'Entwurf')                       
    										SET IDENTITY_INSERT [dbo].[pvw_AbsenceStatusType] OFF
                ");    
                .....
            }
            
            public override void Down()
            {
                ........
            }
