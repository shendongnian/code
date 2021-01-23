    ...
    Criteria = new FilterExpression
    {
      FilterOperator = LogicalOperator.Or,
      Filters =
      {
        new FilterExpression
        {
          FilterOperator = LogicalOperator.And,
          Conditions =
          {
            new ConditionExpression("field1", ConditionOperator.NotNull),
            new ConditionExpression("field2", ConditionOperator.NotNull)
          }
        },
        new FilterExpression
        {
          FilterOperator = LogicalOperator.And,
          Conditions =
          {
            new ConditionExpression("field3", ConditionOperator.NotNull),
            new ConditionExpression("field4", ConditionOperator.NotNull)
          }
        }
      }
    }
    ...
