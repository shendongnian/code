    public override Expression<Func<Attachment, bool>> MatchingCriteria
    {
      get { return a => a.Activity.Parent.ActivityUsers.Any(x => (x.User.Id == id)) 
    				 || a.Activity.ActivityUsers.Any(x => (x.User.Id == id)); 
    	  }
    }
