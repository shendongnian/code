    RetrieveAttributeRequest request = new RetrieveAttributeRequest
    {
      EntityLogicalName = "beep",
      LogicalName = "pickaboo",
      RetrieveAsIfPublished = true
    };
    RetrieveAttributeResponse response 
      = proxy.Execute(request) as RetrieveAttributeResponse;
    PicklistAttributeMetadata metaData 
      = response.AttributeMetadata as PicklistAttributeMetadata;
    OptionSetValue option 
      = new OptionSetValue(metaData.OptionSet.Options[0].Value ?? -1);
