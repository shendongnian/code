    private bool DoesFieldExist(String entityName, String fieldName)
    {
      RetrieveEntityRequest request = new RetrieveEntityRequest
      {
        EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes,
        LogicalName = entityName
      };
      RetrieveEntityResponse response = (RetrieveEntityResponse)service.Execute(request);
      return response.EntityMetadata.Attributes.FirstOrDefault(element 
        => element.LogicalName == fieldName) != null;
    }
