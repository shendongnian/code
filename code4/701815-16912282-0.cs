    private void MoveEmailsFromLeadToOpportunity(IOrganizationService service, Guid LeadID, Guid OpportunityID)
    	{    
    		ConditionExpression condition = new ConditionExpression();
    		condition.AttributeName = "regardingobjectid";
    		condition.Operator = ConditionOperator.Equal;
    		condition.Values.Add(LeadID.ToString());
    		var query = new QueryExpression("email");
    		query.Criteria.AddCondition(condition);
    		query.ColumnSet = new ColumnSet(true);
    
    		var emails = service.RetrieveMultiple(query).Entities;
    		foreach (var email in emails)
            {
    			email["regardingobjectid"] = new EntityReference("opportunity", OpportunityID);
    			service.Update(email);
    		}
    	}
