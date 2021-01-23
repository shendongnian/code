    var parts = source.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    var serviceEndPoints2 = (from i in Enumerable.Range(0, parts.Length)
                            let part = parts[i]
                            from j in Enumerable.Range(0, instances)                            
                            select new ServiceEndPoint { Index = i, Uri = part }).ToList();
