    public static ContactEventValue GetContactEventValue(ContactEventType contactEventType, string programCode, string brandCode) {
    	AdvocacyEntities ent = AdvocacyEntities.GetReadOnlyInstance();
    	ContactEventValue value = ent.ContactEventValues.SingleOrDefault(
    	    	x => x.ContactEventTypeID == contactEventType.ContactEventTypeID
    	    	&& (x.ProgramCode ?? "") == (programCode ?? "")
    	    	&& (x.BrandCode ?? "") == (brandCode ?? ""));
