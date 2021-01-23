    private static Entity GetEntityByGuid(
      IOrganizationService service, 
      String entityLogicalName, 
      String fieldToConstrainOn, 
      Guid valuetoConstrainTo)
    {
      var qe = new QueryExpression(entityLogicalName)
      {
        ColumnSet = new ColumnSet(true)
      };
      
      qe.Criteria.AddCondition(
        fieldToConstrainOn, ConditionOperator.Equal, valuetoConstrainTo);
        
      return service.RetrieveMultiple(qe).Entities.FirstOrDefault();
    }
