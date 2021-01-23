    List<Guid> GetAllResultsFromRollupQuery(XrmServiceContext xrm, Guid rollupQueryId)
    {
        var rollupQuery = xrm.GoalRollupQuerySet.Where(v => v.Id == rollupQueryId).First();
        var qa = GetQueryExpression(xrm, rollupQuery.FetchXml);
    
        qa.PageInfo.Count = 1000;
        qa.ColumnSet.AddColumn(rollupQuery.QueryEntityType + "id");
    
        var result = new List<Guid>();
        EntityCollection ec = null;
    
        do
        {
            ec = xrm.RetrieveMultiple(qa);
            ec.Entities.ToList().ForEach(v => result.Add((Guid)v.Attributes[rollupQuery.QueryEntityType + "id"]));
            qa.PageInfo.PageNumber += 1;
    
        } while (ec.MoreRecords == true);
    
    
        return result;
    }
    QueryExpression GetQueryExpression(XrmServiceContext xrm, string fetchXml)
    {
        var req = new FetchXmlToQueryExpressionRequest { FetchXml = fetchXml };
        var result = (FetchXmlToQueryExpressionResponse)xrm.Execute(req);
        return result.Query;
    }
