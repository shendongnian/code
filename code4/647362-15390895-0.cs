    public List<int> ExtractIds(string str)
    {
         MatchCollection matchCollection = Regex.Matches(str, @"(\d)+");
         List<int> ExtractedIds = new List<int>();
         foreach (Match match in matchCollection)
         {
             int theid = int.Parse(match.Value);
             ExtractedIds.Add(theid);
          }
          return ExtractedIds;
     }
