        QueryExpression query = new QueryExpression("supplier");
        query.ColumnSet = new ColumnSet("sendsalesrequest", "noreply", "nofollowupreply");
        EntityCollection entities = service.RetrieveMultiple(query);
        entities.Entities.ToList().ForEach(entity => 
            {
                if(entity["sendsalesrequest"] == "Yes")
                {
                    StartWorkflow(entity.Id, "Send Initial E Mail Workflow Name");
                }
                //etc
            }
