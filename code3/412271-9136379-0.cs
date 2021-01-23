    public static string SerializeToJson(this IDictionary<string, object> dict)
    {
      var sb = new StringBuilder();
      sb.Append("{");
      foreach (string key in dict.Keys)
      {
        sb.AppendFormat("\"{0}\": \"{1}\"", key, dict[key]);
        sb.Append(key != dict.Keys.Last() ? ", " : String.Empty);
      }
      
      sb.Append("}");
      
      return sb.ToString();
    }
