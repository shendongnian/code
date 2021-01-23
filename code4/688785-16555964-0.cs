    public List<Opportunities> GetOpportunitiesList()
    {
        using (_orgService = new OrganizationService(connection))
        {
            OrganizationServiceContext context = new OrganizationServiceContext(_orgService);
            // Create Linq Query.
            DateTime getdate = DateTime.Now.AddDays(-3);
            var query = (from r in context.CreateQuery<Opportunity>()
                         join c in context.CreateQuery<Contact>() on r.ContactId.Id equals c.ContactId
                             into rc
                         from z in rc.DefaultIfEmpty()
                         where r.CreatedOn > getdate && r.new_type != null
                         orderby r.ContactId
                         select new Opportunities
                         {
                             opporunity = r.new_OpportunityNumber,
                             //region =GetAccountRegionsbyId(a.new_region.Value),  
                             accountid = r.CustomerId.Id,
                             topic = r.Name,
                             status = r.StateCode.Value.ToString(),
                             pcustomer = r.CustomerId.Name,
                             estReve = (decimal)r.EstimatedValue.Value,
                             owner = r.OwnerId.Name,
                             salesstagecode = r.SalesStageCode.Value,
                             pipelinePhase = r.StepName,
                             opptype = getAllOptionSetValues(r.LogicalName, "new_sf_recordtype", r.new_sf_recordtype.Value),
                             subtype = getAllOptionSetValues(r.LogicalName, "new_type", r.new_type == null ? default(int) : r.new_type.Value),
                             estclosedate = r.EstimatedCloseDate.Value,
                             actualRev = (Microsoft.Xrm.Sdk.Money)r.ActualValue,
                             probability = r.CloseProbability.Value,
                             weighedRev = (decimal)r.new_WeightedValue.Value,
                             Email = z.EMailAddress1,
                             CreatedOn = r.CreatedOn.Value,
                             modifiedBy = r.ModifiedBy.Name,
                             modifiedOn = r.ModifiedOn.Value
                         }).ToList();
            foreach (Opportunities o in query)
            {
                o.region = (from d in context.CreateQuery<Account>() where d.AccountId == o.accountid select getAllOptionSetValues(d.LogicalName, "new_region", d.new_region.Value)).FirstOrDefault();
             }
            return query;
        }
    }
