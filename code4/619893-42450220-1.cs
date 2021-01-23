    public IDictionary ConvertQueryString(string sQry)
    {
        string pattern = @"(?<Prop>[^[]+)(?:\[(?<Key>[^]]+)\])*=(?<Value>.*)";
        // The brackets seem to be encoded as %5B and %5D
        var qry = HttpUtility.UrlDecode(sQry);
        var re = new Regex(pattern);
        var dict = qry.Split(new[] { "?", "&" }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(s => re.Match(s)).Where(g => g.Success)
                   .GroupBy(m => m.Groups["Prop"].Value)
                   .ToDictionary<IGrouping<string, Match>, string, object>(
                        g => g.Key, 
                        g => GetKey(g, 0));
        return dict;
    }
    private object GetKey(IGrouping<string, Match> grouping, int level)
    {
        var count = grouping.FirstOrDefault().Groups["Key"].Captures.Count;
        // If the level is equal to the captures, then we are at the end of the indexes
        if (count == level)
        {
            var gValue = grouping.Where(gr => gr.Success).FirstOrDefault();
            var value = gValue.Groups["Value"].Value;
            return value;
        }
        else
        {
            return grouping.Where(gr => gr.Success)
                    .GroupBy(m => m.Groups["Key"].Captures[level].Value)
                    .ToDictionary<IGrouping<string, Match>, string, object>(
                            a => a.Key, 
                            a => GetKey(a, level + 1));
        }
    }
