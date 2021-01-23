    OrganizationServiceProxy orgserv;    
    using(var xrm = new XrmServiceContext(orgserv))
        {
         //Opportunity currentOpportunity = ...
            
         IQueryable<ActivityPointer> activityPointers = xrm.ActivityPointerSet.Where(a =>
           a.RegardingObjectId == currentOpportunity.ToEntityReference());
        }
