    protected void ApplyTemplateFilter(CombinedQuery query, string templateIds)
    {
      if (String.IsNullOrEmpty(templateIds)) return;
      var fieldQuery = new CombinedQuery();
      var values = IdHelper.ParseId(templateIds);
      foreach (var value in values.Where(ID.IsID))
      {
        AddFieldValueClause(fieldQuery, BuiltinFields.Template, value, QueryOccurance.Should);
      }
      query.Add(fieldQuery, QueryOccurance.Must);
    }
