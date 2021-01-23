    CreateTable(
        "dbo.PrivateMakeUpLessons",
        c => new
            {
                ID = c.Guid(nullable: false),
                ...
            })
        .PrimaryKey(t => t.ID)
        .ForeignKey("dbo.Lessons", t => t.ID)
        .ForeignKey("dbo.Cancellations", t => t.ID)
        .Index(t => t.ID)
        .Index(t => t.ID); // <-- Remove this
