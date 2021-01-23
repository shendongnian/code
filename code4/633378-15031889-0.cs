    private Guid GetGuidByEmail(String email)
    {
      QueryExpression query = new QueryExpression
      {
        EntityName = "lead",
        ColumnSet = new ColumnSet("emailaddress1"),
        Criteria = new FilterExpression
        {
          Filters =
          {
            new FilterExpression
            {
              Conditions =
              {
                new ConditionExpression("emailaddress1", ConditionOperator.Equals, email)
              }
            }
          }
        }
      };
    
      Entity entity = service.RetrieveMultiple(query).Entities.FirstOrDefault();
      if(entity != null)
        return entity.Id;
      return Guid.Empty;
    }
