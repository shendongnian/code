    public IEnumerable<Newtonsoft.Json.Linq.JToken> GetAllStatistics()
    {
        var results = oCouchbase.GetView("Statistics", "TotalPosts");
        foreach(var row in results)
        {
            yield return oCouchbase.Get<Newtonsoft.Json.Linq.JToken>(row.ItemId);
        }
    }
