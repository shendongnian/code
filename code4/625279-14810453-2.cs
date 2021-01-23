    i =>
    {
        var cluster = new Cluster { Id = i };
        // rest of the loop here
        if (cluster.Blobs.Count > 2)
        {
            lock (this.Clusters)
            {
                this.Clusters.Add(cluster);
            }
        }
    }
