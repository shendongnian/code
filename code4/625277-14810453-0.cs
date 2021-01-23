    i =>
    {
        var cluster = new Cluster { Id = i };
        // rest of the loop here
        lock (this.Clusters)
        {
            if (cluster.Blobs.Count > 2)
            {
                this.Clusters.Add(cluster);
            }
        }
    }
