    public static Guid GetYearID(string yearName) 
    {
        ICrmService service = CrmServiceFactory.GetCrmService(); 
    
        // Create the query object. 
        QueryExpression query = new QueryExpression("year"); 
    
        //No need to ask for the id, it is always returned
        //ColumnSet columns = new ColumnSet(); 
        //columns.AddColumn("yearid");
        //query.ColumnSet = columns;
    
        FilterExpression filter = new FilterExpression(); 
    
        filter.FilterOperator = LogicalOperator.And; 
        filter.AddCondition(new ConditionExpression 
        { 
            AttributeName = "yearName", 
            Operator = ConditionOperator.Equal, 
            Values = new object[] { yearName} 
        }); 
    
        query.Criteria = filter; 
    	
        //We have to use a retrieve multiple here
        //In theory we could get multiple results but we will assume we only ever get one
        BusinessEntityCollection years = service.RetrieveMultiple(query);
    
        DynamicEntity year = (DynamicEntity)years.BusinessEntities.First();
    
        return ((Guid)year["yearid"]);
    }  
