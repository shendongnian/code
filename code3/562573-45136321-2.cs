    public override void Up()
      {
            RenameColumn("dbo.your_database", "oldColumn",          
           "newColumn");
      }
      
    
    public override void Down()
      {
        	RenameColumn("dbo.your_database", "newColumn", 
            "oldColumn");
      }
    
