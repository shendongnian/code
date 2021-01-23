    RetrieveAttributeRequest attributeRequest = new RetrieveAttributeRequest();
    attributeRequest.EntityLogicalName = <your entity name>;
    attributeRequest.LogicalName = <your picklist attribute name>;
    attributeRequest.RetrieveAsIfPublished = true;
    
    RetrieveAttributeResponse response = (RetrieveAttributeResponse)metaService.Execute(attributeRequest);
    PicklistAttributeMetadata picklist = (PicklistAttributeMetadata)response.AttributeMetadata;
    
    
    foreach (Option o in picklist.Options)
    {
        // do something e.g. take o.ValueValue
    }
