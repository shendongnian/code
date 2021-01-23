    var parts = source.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    var serviceEndPoints = (from i in Enumerable.Range(0, instances * parts.Length)
                            let j = i / instances
                            let part = parts[j]
                            select new ServiceEndPoint { Index = j, Uri = part }).ToList();
