    IEnumerable<T> query = List1;
    foreach (var property in IndexFields)
    {
      // The variable "property" gets hoisted out of local context
      // which messes you up if the query is being evaluated with
      // delayed execution.
      var localProperty = property;
      query = query.Where(
        p => (p.GetType().GetProperty(localProperty)
                         .GetValue(p, null) as string) == "red");
    }
    var sitem = query.FirstOrDefault();
