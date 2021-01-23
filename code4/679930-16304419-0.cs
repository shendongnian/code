    StringBuilder sb = new StringBuilder();
    ...
    if(criteria1)
    {
      sb.Append(" And Criteria>1");
    }
    ...
    if(criteria2)
    {
      sb.Append(" And Criteria2<15");
    }
    ...
    var result = context.People.Where(sb.ToString()).ToList();
