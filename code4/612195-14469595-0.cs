    // Create the new objects    
    var statement = new StatementsMain()
    {
    	this.LocalGovt.StakeholderID, 161, this.Year.FinancialYearID
    };
    
    var income = new StatementsIncome()
    {
    	StatementsMain = statement
    };
    
    var note = new StatementsNote()
    {
    	StatementsMain = statement
    };
    
    var rss = new StatementsRSSFinPos()
    {
    	StatementsMain = statement
    };
    
    var surplus = new StatementsSurplusDeficit()
    {
    	StatementsMain = statement
    };
    
    
    // Add the objects into the context 
    lGFinancialEntities.AddObject(statement);
    lGFinancialEntities.AddObject(income);
    lGFinancialEntities.AddObject(note);
    lGFinancialEntities.AddObject(rss);
    lGFinancialEntities.AddObject(surplus);
      
    // Persist the objects to the data storage
    lGFinancialEntities.SaveChanges();
