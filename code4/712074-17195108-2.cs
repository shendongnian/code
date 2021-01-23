    var keys = _metrics.Keys.ToList();
    var values = new List<Metric>();
    foreach (var key in keys)
    {
        Metric metric;
        if (_metrics.TryRemove(key, out metric))
        {
            values.Add(metric);
        }
    }
    return values;
