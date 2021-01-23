    private string RecreateQuery(IfxCommand query)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(query.CommandText);
      foreach (IfxParameter parameter in query.Parameters)
        sb.Replace(" ? ", string.Format(" {0} ", parameter.Value.ToString()));
      return sb.ToString();
    }
