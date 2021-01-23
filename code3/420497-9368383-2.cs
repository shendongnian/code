    items.ToLookup(c=>c.Institution.InstitutionId, c => new {c.Designation, c.Owner, c.Event})
    	.Select(c => new {
    	    // find the institution using the original Holding list
    		Institution = items.First(i=>i.Institution.InstitutionId == c.Key).Institution,
    		// create a new property which will hold the groupings by Designation and Onwner
    		DesignationOwner = 
    				// group (Designation, Owner, Event) of each Institution by Designation and Owner; Select Event as the grouping result
    				c.ToLookup(_do => new {_do.Designation, _do.Owner.OwnerId}, _do => _do.Event)
    							.Select(e => new {
    								// create a new Property Designation, from e.Key
    								Designation = e.Key.Designation,
    								// find the Owner from the upper group ( you can use items as well, just be carreful this is about object and will get the first match in list)
    								Owner = c.First(o => o.Owner.OwnerId == e.Key.OwnerId).Owner,
    								// select the grouped events // want Distinct? call Distinct
    								Events = e.Select(ev=>ev)//.Distinct()
    							})
    	})
