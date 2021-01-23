        // Setup the CrmConnection and OrganizationService instances
        CrmConnectionInstance = new CrmConnection(ConfigurationConstants.CrmConnectionName);
    OrgServiceInstance = new OrganizationService(CrmConnectionInstance);
        // Create the marketing list 
        Guid NewMarketingListId = Guid.Empty; 
        Microsoft.Xrm.Sdk.Entity CurrentList = new Microsoft.Xrm.Sdk.Entity(MarketingListConstants.MarketingListEntityName); 
        CurrentList[MarketingListConstants.MarketingListTypeAttribute] = false; 
        CurrentList[MarketingListConstants.ListNameAttribute] = "NameOfList"; 
        // For contacts, a value of 2 should be used. 
        CurrentList[MarketingListConstants.CreatedFromCodeAttribute] = new OptionSetValue(2); 
        // Actually create the list 
        NewMarketingListId = OrgServiceInstance.Create(CurrentList); 
        // Use the AddListMembersListRequest to add the members to the list 
        List<Guid> MemberListIds = new List<Guid>(); 
        // Now you'll need to add the Guids for each member to the list  
        // I'm leaving that part out as adding values to a list is very basic. 
        AddListMembersListRequest AddMemberRequest = new AddListMembersListRequest(); 
        AddMemberRequest.ListId = NewMarketingListId; 
        AddMemberRequest.MemberIds = memberIds.ToArray(); 
        // Use AddListMembersListReponse to get information about the request execution 
        AddListMembersListResponse AddMemberResponse = OrgServiceInstance.Execute(AddMemberRequest) as AddListMembersListResponse;
