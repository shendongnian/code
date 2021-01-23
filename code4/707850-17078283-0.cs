    public IQueryable<Post> Search(string criteria, int x)
    {
      var allCriteria = criteria.Split(',');
    
      var result=db.Posts.Where(p => 
          allCriteria.Any(c=>p.PostText.Contains(c))
          || allCriteria.Any(c=>p.Weather.Contains(c))
          || allCriteria.Any(c=>p.Location.Contains(c))
        ).Where(p=>p.IsActive)
        .OrderByDescending(p => p.PostDate)
        .Take(x);
      return result;
    }
