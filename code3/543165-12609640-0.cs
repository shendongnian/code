        public static QueryExpression BuildQueryExpression(String entityName, ColumnSet columnSet, LogicalOperator logicalOperator, List<ConditionExpression> conditions)
        {
            QueryExpression query = new QueryExpression(entityName);
            query.ColumnSet = columnSet;
            query.Criteria = new FilterExpression(logicalOperator);
            conditions.ForEach(c => query.Criteria.AddCondition(c));
            return query;
        }
