     public override void Up()
       {
		    RenameColumn("dbo.ProductCategories", "ChangeColumn",          
           "HaveChangedColumn");
  	  }
        
    
   
        public override void Down()
          {
    	    	RenameColumn("dbo.ProductCategories", "HaveChangedColumn", 
                "ChangeColumn");
          }
     
      
    
