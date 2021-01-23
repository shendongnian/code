    () => new List<Cluster>(),
    (i, loop, clusters) =>
    {
        var cluster = new Cluster { Id = i };
        // rest of the loop here
        if (cluster.Blobs.Count > 2)
            clusters.Add(cluster);
        return clusters;
    },
    clusters =>
    {
        lock (this.Clusters)
        {
            this.Clusters.AddRange(clusters);
        }
    }
