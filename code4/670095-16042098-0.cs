    // Requesting user's access rights to current record
    var principalAccessRequest = new RetrievePrincipalAccessRequest
    {
        Principal = new EntityReference("systemuser", localContext.PluginExecutionContext.UserId),
        Target = new EntityReference(localContext.PluginExecutionContext.PrimaryEntityName, localContext.PluginExecutionContext.PrimaryEntityId)
    };
    // Response will contain AccessRights mask, like AccessRights.WriteAccess | AccessRights.ReadAccess | ...
    var principalAccessResponse = (RetrievePrincipalAccessResponse)localContext.OrganizationService.Execute(principalAccessRequest);
    if ((principalAccessResponse.AccessRights & AccessRights.WriteAccess) != AccessRights.None)
    {
        ...
        ...
        ...
    }
