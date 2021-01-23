    // Create the main object
    var statement = new StatementsMain()
    {
    	this.LocalGovt.StakeholderID, 161, this.Year.FinancialYearID
    };
    
    // Add the objects into the context
    lGFinancialEntities.AddObject(statement);
    lGFinancialEntities.AddObject(new StatementsIncome() { StatementsMain = statement });
    lGFinancialEntities.AddObject(new StatementsNote() { StatementsMain = statement });
    lGFinancialEntities.AddObject(new StatementsRSSFinPos() { StatementsMain = statement });
    lGFinancialEntities.AddObject(new StatementsSurplusDeficit() { StatementsMain = statement });
    
    // Persist the objects to the data storage
    lGFinancialEntities.SaveChanges();
