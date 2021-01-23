        var dictState = new Dictionary<int, OptionMetadata>();
    	var dictStatus = new Dictionary<int, List<OptionMetadata>>();
    
    	string entityName = "lead";
    	int count=0;
    	using (var orgServiceProxy = GetOrgServiceProxy(orgServiceUriOnLine))
    	{
    		RetrieveAttributeResponse attributeResponse = GetAttributeData(orgServiceProxy, entityName, "statecode");
    		AttributeMetadata attrMetadata = (AttributeMetadata)attributeResponse.AttributeMetadata;
    		StateAttributeMetadata stateMetadata = (StateAttributeMetadata)attrMetadata;
    		foreach (OptionMetadata optionMeta in stateMetadata.OptionSet.Options)
    		{
    			dictState.Add(optionMeta.Value.Value,optionMeta);
    			dictStatus.Add(optionMeta.Value.Value,new List<OptionMetadata>());
    		}
    
    		attributeResponse = GetAttributeData(orgServiceProxy, entityName, "statuscode");
    		attrMetadata = (AttributeMetadata)attributeResponse.AttributeMetadata;
    		StatusAttributeMetadata statusMetadata = (StatusAttributeMetadata)attrMetadata;
    		
    		foreach (OptionMetadata optionMeta in statusMetadata.OptionSet.Options)
    		{
    			int stateOptionValue = ((StatusOptionMetadata)optionMeta).State.Value;
    			var statusList = dictStatus[stateOptionValue];
    			statusList.Add(optionMeta);
    			count++;
    		}
    	}
    	Console.WriteLine($"Number of mappings: {count}");
    	foreach (var stateKvp in dictState.OrderBy(x=> x.Key))
    	{
    		Console.WriteLine($"State: {stateKvp.Value.Value}: {stateKvp.Value.Label.UserLocalizedLabel.Label}");
    		var statusList = dictStatus[stateKvp.Key];
    		Console.WriteLine($"\tStatuses");
    		foreach (var status in statusList.OrderBy(s => s.Value))
    		{
    			Console.WriteLine($"\t\t{stateKvp.Value.Value}: {status.Label.UserLocalizedLabel.Label}");
    		}
    	}
