    int soFar = 0;
    Dictionary<int, int> counts = grouped.ToDictionary(g => g.Key, g => g.Count());
    foreach(int key in counts.Keys.OrderByDescending(i => i))
    {
      soFar += counts[key];
      counts[key] = soFar;
    }
