    _serviceProxy = new OrganizationServiceProxy(serverConfig.OrganizationUri, serverConfig.HomeRealmUri,
                    serverConfig.Credentials, serverConfig.DeviceCredentials);
    _serviceProxy.EnableProxyTypes();
    _service = _serviceProxy;
    RetrieveAttributeRequest retrieveAttributeRequest =
        new RetrieveAttributeRequest
        {                            
            EntityLogicalName = EntityLogicalName,
            LogicalName = optionSetLogicalName,
            RetrieveAsIfPublished = true,
        };
    // Execute the request.
    RetrieveAttributeResponse retrieveAttributeResponse =
        (RetrieveAttributeResponse)_service.Execute(
        retrieveAttributeRequest);
    // Access the retrieved attribute.
    PicklistAttributeMetadata retrievedPicklistAttributeMetadata =
        (PicklistAttributeMetadata)
        retrieveAttributeResponse.AttributeMetadata;
    // Get the current options list for the retrieved attribute.
    OptionMetadata[] optionList =
        retrievedPicklistAttributeMetadata.OptionSet.Options.ToArray();
    //Dictionary<int,string> LocalizedLabelDic = new Dictionary<int,string>();
    List<ListItem> OptionSetItems = new List<ListItem>();
    foreach (OptionMetadata o in optionList)
    {
        OptionSetItems.Add(new ListItem(o.Label.LocalizedLabels.FirstOrDefault(e => e.LanguageCode == 1033).Label.ToString(), o.Value.Value.ToString()));
    }
