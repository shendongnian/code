    string[] tagNames = new string[2]{ "Admins", "Users" };
    IList<string> otherTags = 
        session.QueryOver<Tag>()
    	       .WhereRestrictionOn(x => x.Name).Not.IsIn(tagNames)
    	       .Select(x => x.Name)
    	       .List<string>();
    
    string[] otherTagNames = new string[otherTags.Count];
    otherGroups.CopyTo(otherTagNames, 0);
    					  
    IList<Blog> blogsFound = 
        session.QueryOver<Blog>()
    	       .Right.JoinQueryOver<Tag>(x => x.Tags)
    	       .WhereRestrictionOn(x => x.Name).IsIn(tagNames)
    	       .WhereRestrictionOn(x => x.Name).Not.IsIn(otherTagNames)
    	       .List<Blog>();
