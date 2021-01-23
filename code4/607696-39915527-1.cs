    try
    {
        var query = new QueryExpression("account");
        query.Criteria.AddCondition("accountid", ConditionOperator.Equal, "294450db-46c9-447e-a642-3babf913d800");
        query.NoLock = true;
        query.ColumnSet = new ColumnSet("xyz_fieldname");
        service.RetrieveMultiple(query);
    }
    catch
    {
        // ignored
    }
