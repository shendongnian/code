        FilterExpression _filter = new FilterExpression(LogicalOperator.And);
        _filter.AddCondition("firstname", ConditionOperator.Equal, "Joe");
        _filter.AddCondition("firstname", ConditionOperator.Equal, "John");
        dynamic _queryExpression = new QueryExpression {
	EntityName = Contact.EntityLogicalName,
	ColumnSet = new ColumnSet(true),
	Criteria = _filter
        };
