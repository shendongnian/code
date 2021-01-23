    QueryExpression query = new QueryExpression("systemuser");
    query.ColumnSet = new ColumnSet(new string[] { "systemuserid" });
    query.Distinct = true;
    query.Criteria = new FilterExpression();
    query.Criteria.AddCondition("businessunitid", ConditionOperator.Equal, ((EntityReference)entity.Attributes["new_unit"]).Id);
    query.AddLink("systemuserroles", "systemuserid", "systemuserid").
        LinkCriteria.AddCondition("roleid", ConditionOperator.Equal, roleIdGuid);
    
    var users = organizationService.RetrieveMultiple(query);
