    private EntityCollection GetLeadsWithEmail(
      IOrganizationService service, String wantedEmailAddress)
    {
      QueryExpression query = new QueryExpression();
      query.EntityName = "lead";
      // the columns you want
      query.ColumnSet = new ColumnSet() { AllColumns = true };
      query.Criteria = new FilterExpression();
      query.Criteria.FilterOperator = LogicalOperator.And;
      query.Criteria.Conditions.Add(new ConditionExpression(
        "emailaddress1", ConditionOperator.Equal, wantedEmailAddress));
      return service.RetrieveMultiple(query);
    }
