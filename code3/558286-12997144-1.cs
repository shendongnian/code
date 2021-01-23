    while (!data.All(d => d.IsCompleted))
    {
        foreach (var d in data)
        {
            // only takes elements from the collection if it has more than 2 elements
            if (d.Count >= 2)
            {
                double x1, x2;
                if (d.TryTake(out x1) && d.TryTake(out x2))
                {
                    if (x1 * x2 < 0.0)
                        peakCounter++;
                }
                else
                    throw new InvalidOperationException();
            }
        }
    }
