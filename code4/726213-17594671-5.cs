    IEnumerable<IDictionary<string, object>> Merger(
            IEnumerable<IDictionary<string, object>> source,
            IEnumerable<string> keys,
            IDictionary<string, Func<IEnumerable<object>, object>> aggregators)
    {
        var grouped = source.GroupBy(d => string.Join("|", keys.Select(k => d[k])));
        
        foreach(var g in grouped)
        {
            var result = new Dictionary<string, object>();
            var first = g.First();
            foreach(var key in keys)
            {
                result.Add(key, first[key]);
            }
            foreach(var a in aggregators)
            {
                result.Add(a.Key, a.Value(g.Select(i => i[a.Key])));
            }
            yield return result;
        }
    }
