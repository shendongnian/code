            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(maxLength: 4000),
                        QuestionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        OptionID = c.Long(nullable: false),
                        QuestionID = c.Long(nullable: false),
                        DependencyType = c.Int(nullable: false),
                        DependencyNote = c.String(maxLength: 4000),
                        Active = c.Boolean(nullable: false),
                        UseEtc = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.OptionID, t.QuestionID })
                .ForeignKey("dbo.Options", t => t.OptionID)
                .ForeignKey("dbo.Questions", t => t.QuestionID)
                .Index(t => t.OptionID)
                .Index(t => t.QuestionID);
