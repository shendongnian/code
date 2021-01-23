    public override Expression<Func<Attachment, bool>> MatchingCriteria
    {
      get 
      {
         return a => a.Activity.Parent.Any(a2 => a2.ActivityUsers.Any(x => (x.User.Id == id) || x.Activity.ActivityUsers.Any(x => x.User.Id == id)));
      }
    }
