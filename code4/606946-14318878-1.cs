    q_ShoppingCartItemQuantityCheck.Criteria = new FilterExpression(); 
    q_ShoppingCartItemQuantityCheck.Criteria.FilterOperator = LogicalOperator.Or;
    FilterExpression filter1 = q_ShoppingCartItemQuantityCheck.Criteria.AddFilter(LogicalOperator.And);
    filter1.Conditions.Add(new ConditionExpression("systemLogicalName", ConditionOperator.Equal, systemid));
    filter1.Conditions.Add(new ConditionExpression("productLogicalName", ConditionOperator.Equal, productid));
    FilterExpression filter2 = q_ShoppingCartItemQuantityCheck.Criteria.AddFilter(LogicalOperator.And);
    filter2.Conditions.Add(new ConditionExpression("productLogicalName", ConditionOperator.Equal, productid));
    filter2.Conditions.Add(new ConditionExpression("licenceLogicalName", ConditionOperator.Equal, true));
