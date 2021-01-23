    QueryExpression query = new QueryExpression("systemuser");
    query.ColumnSet = new ColumnSet(new string[] { "systemuserid" });
    query.Distinct = true;
    query.Criteria = new FilterExpression();
    query.Criteria.AddCondition("businessunitid", ConditionOperator.Equal, ((EntityReference)entity.Attributes["new_unit"]).Id);
    query.AddLink("systemuserroles", "systemuserid", "systemuserid").
        AddLink("role","roleid", "roleid").LinkCriteria.AddCondition("name", ConditionOperator.Equal, "MyRoleName");
    
    var users = organizationService.RetrieveMultiple(query);
