    string languageCode = germanLanguageCode; // Set
    int optSetValue =  0; // Set
    RetrieveAttributeRequest attributeRequest = new RetrieveAttributeRequest
    {
        EntityLogicalName = entityLogicalName,
        LogicalName = attributeName,
        RetrieveAsIfPublished = true
    };
    
    var response = (RetrieveAttributeResponse)service.Execute(attributeRequest);
    var optionList = ((EnumAttributeMetadata)response.AttributeMetadata).OptionSet.Options;
    
    return optionList.GetFirst(o => o.Value == optSetValue).Label.LocalizedLabels.First(l => l.LanguageCode == languageCode).Label;
