    public static dynamic GetOptionSet(string entityName, string fieldName, int langId, OrganizationServiceProxy proxy)
    {
        RetrieveEntityRequest retrieveDetails = new RetrieveEntityRequest();
        retrieveDetails.EntityFilters = EntityFilters.All;
        retrieveDetails.LogicalName = entityName;
        RetrieveEntityResponse retrieveEntityResponseObj = (RetrieveEntityResponse)proxy.Execute(retrieveDetails);
        EntityMetadata metadata = retrieveEntityResponseObj.EntityMetadata;
        PicklistAttributeMetadata picklistMetadata = metadata.Attributes.FirstOrDefault(attribute => String.Equals(attribute.LogicalName, fieldName, StringComparison.OrdinalIgnoreCase)) as PicklistAttributeMetadata;
        OptionSetMetadata options = picklistMetadata.OptionSet;
        var optionlist = (from o in options.Options
                              select new { Value = o.Value, Text = o.Label.LocalizedLabels.First(l => l.LanguageCode == langId).Label }).ToList();
        return optionlist;
    }
