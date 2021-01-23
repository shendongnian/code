        public static List<Dictionary<string, object>> SearchList(List<Dictionary<string, object>> testData, Dictionary<string, object> searchPattern)
        {
            return testData.Where(t =>
                {
                    bool flag = false;
                    foreach (KeyValuePair<string, object> p in searchPattern)
                    {
                        if (t.ContainsKey(p.Key) && t[p.Key].Equals(p.Value))
                        {
                            flag = true;
                            break;
                        }
                    }
                    return flag;
                }).ToList();
        }
