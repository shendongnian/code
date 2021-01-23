    //Build the QueryExpression, the condition should give us a single record
    QueryExpression query = new QueryExpression("contact");
    query.Criteria = new FilterExpression();
    query.Criteria.AddCondition(new ConditionExpression("someidfield", ConditionOperator.Equal, "ABC123");
    
    BusinessEntityCollection entities = service.RetrieveMultiple(query);
    
    //In theory we could get multiple records here, but we will assume we only get the one
    DynamicEntity contact = (DynamicEntity)entities.BusinessEntities.First();
    Guid existingContactId = (Guid)contact["contactid"];
    Lookup lookupToExisitingContact = new Lookup();
    lookupToExisitingContact.Value = existingContactId;
    lookupToExisitingContact.type = "contact";
    
    DynamicEntity newContact = new DynamicEntity("contact");
    newContact["firstname"] = "James";
    newContact["parentcontactid"] = lookupToExisitingContact;
    service.Create(newContact);
