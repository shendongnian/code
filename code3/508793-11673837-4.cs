    // e.g. class Models { Complete; Partial }
    // private Models Search(string source, int offset, int length, int ID)
    var tasks = new List<Task<Models>>(
        from x in Enumerable.Range(0, s.Length / lenCutoff)
        select Task.Factory.StartNew<Models>(
            () => Search(s, x, lenCutoff, strandID));
    );
    // private Models CombineResults(IEnumerable<Models> results)
    var combine = Task.Factory.ContinueWhenAll<Models>(
        tasks.ToArray(),
        ts => CombineResults(ts.Select(t => t.Result)));
    combine.Wait();
    Models combinedModels = combine.Result;
