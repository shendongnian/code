        public static List<Dictionary<string, object>> SearchList(List<Dictionary<string, object>> testData, Dictionary<string, object> searchPattern)
        {
            return testData
                      .Where(t => searchPattern.All(p => t.ContainsKey(p.Key) && 
                                                         t[p.Key].Equals(p.Value)))
                      .ToList();
        }
