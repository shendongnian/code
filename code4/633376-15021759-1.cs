    private EntityCollection GetLeadsWithEmail(IOrganizationService service, string wantedEmailAddress)
    {
        QueryExpression query = new QueryExpression();
        query.EntityName = "lead";
        query.ColumnSet = new ColumnSet() { AllColumns = true }; // or the columns you want
        query.Criteria = new FilterExpression();
        query.Criteria.FilterOperator = LogicalOperator.And;
        query.Criteria.Conditions.Add
        (
                new ConditionExpression("emailaddress1", ConditionOperator.Equal, wantedEmailAddress)
        );
        return service.RetrieveMultiple(query);
    }
