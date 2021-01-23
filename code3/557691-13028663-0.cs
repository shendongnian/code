    EntityCollection Recipients = email.GetAttributeValue<EntityCollection>("to");
    foreach (var party in Recipients.Entities)
    {  
    var partyName = party.GetAttributeValue<EntityReference>("partyid").Name;
    var partyId = party.GetAttributeValue<EntityReference>("partyid").Id;
    
    …
    }
