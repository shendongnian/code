    query.Criteria = new FilterExpression(); 
    query.Criteria.FilterOperator = LogicalOperator.Or;
    FilterExpression filter1 = query.Criteria.AddFilter(LogicalOperator.And);
    filter1.Conditions.Add(new ConditionExpression("A_LogicalName", ConditionOperator.Equal, id1));
    filter1.Conditions.Add(new ConditionExpression("B_LogicalName", ConditionOperator.Equal, id2));
    FilterExpression filter2 = query.Criteria.AddFilter(LogicalOperator.And);
    filter2.Conditions.Add(new ConditionExpression("B_LogicalName", ConditionOperator.Equal, id2));
    filter2.Conditions.Add(new ConditionExpression("C_LogicalName", ConditionOperator.Equal, id3));
