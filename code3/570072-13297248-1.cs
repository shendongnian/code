    public override void Up()
    {
        RenameTable("ReportSections", "ReportPages");
        RenameTable("ReportSectionGroups", "ReportSections");
        RenameColumn("ReportPages", "Group_Id", "Section_Id");
    }
        
    public override void Down()
    {
        RenameColumn("ReportPages", "Section_Id", "Group_Id");
        RenameTable("ReportSections", "ReportSectionGroups");
        RenameTable("ReportPages", "ReportSections");
    }
