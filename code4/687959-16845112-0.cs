    Guid emailID = context.PostEntityImages["PostImage"].Id;
    Entity emailFromRetrieve = localContext.OrganizationService.Retrieve(
        "email",
        emailID,
        new Microsoft.Xrm.Sdk.Query.ColumnSet(true));
    Email email = emailFromRetrieve.ToEntity<Email>();
    if (email.RegardingObjectId == null)
    {
        return;
    }
    var regardingObject = email.RegardingObjectId;
