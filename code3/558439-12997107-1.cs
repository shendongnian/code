    List<SomeObject> CustomSort( List<SomeObject> list)
    {
    
      var ordered = list.OrderBy(x => x.TargetObject); // might not be necessary. Not sure if group by orders the group or not.
      var groups = ordered.GroupBy(x => x.x.TargetObject);
      List<SomeObject> res = new List<SomeObject>();
    
      int position = 0;
      while(res.Count < list.Count)
      {
        foreach (var grp in groups)
        {
            SomeObject current = grp.ElementAtOrDefault(position);
            if ( current != null) res.Add(current);
        }
        position ++;
      }
      return res;
    }
