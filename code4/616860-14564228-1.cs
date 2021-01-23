    var sampleContact = new { ContactKey = 0L, /* etc */ };
    var sampleContactList = new[] { sampleContact }.ToList();
    var contactGroup = new[] { new { ContactGroupKey = 0L,
                                     ContactGroupTLK = 0L, 
                                     Desc = "", 
                                     Contacts = sampleContactList } }.ToList();
