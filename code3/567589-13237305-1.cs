    public string SanitizeField(SearchResultCollection result, string field)
    {
      StringBuilder sb = new StringBuilder();
      foreach (object val in result[0].Properties[field])
      {
        sb.Append("<" + field + ">" + val + "</" + field + ">");
      }
      return sb.ToString();
    }
