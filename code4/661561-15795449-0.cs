    int getPicklistValueByName(string picklistName, string entityLogicalName, string logicalName, MetadataService metaService)
    {
       int retval = -1;
       
       RetrieveAttributeRequest attributeRequest = new RetrieveAttributeRequest();
       attributeRequest.EntityLogicalName = entityLogicalName;
       attributeRequest.LogicalName = kogicalName;
    
       var attributeResponse = (RetrieveAttributeResponse)metaService.Execute(attributeRequest);
       var picklist = (PicklistAttributeMetadata)attributeResponse.AttributeMetadata;
    
       return picklist.Options.Where(op => op.Label.UserLocLabel.Label == picklistName).Single().Value.Value;
    }
