    class AcccountFieldsByName {
    // check, userGroup, ipReply, routeReply
     
        static AcccountFieldsByName Read(... _entities, string userName)    
    	{
    	return new AcccountFieldsByName {
    		check = _entities.Checks.Single(x => x.UserName == userName),
    		userGroup = _entities.UserGroups.Single(x => x.UserName == userName),
    		ipReply = _entities.Replies.Single(x => x.UserName == userName && x.Attribute == "Framed-IP-Address"),
    		routeReply = _entities.Replies.Single(x => x.UserName == userName && x.Attribute == "Framed-Route"),
    		}
    	}
    }
