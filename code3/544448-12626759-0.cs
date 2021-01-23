    QueryExpression qryAccounts = new QueryExpression("account")
    {
    	ColumnSet = new ColumnSet("accountid", "name", "primarycontactid")
    };
    
    qryAccounts.Criteria.AddCondition("primarycontactid", ConditionOperator.NotNull);
    qryAccounts.AddLink("list", "accountid", "entityid");
    
    EntityCollection collAccounts = svcOrganization.RetrieveMultiple(qryAccounts);
