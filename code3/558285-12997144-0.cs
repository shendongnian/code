    while (!data.Any(d => d.IsCompleted))
    {
        double x1, x2;
        foreach (var d in data)
        {
            try
            {
                x1 = d.Take();
                x2 = d.Take();
            }
            catch (InvalidOperationException)
            {
                break;
            }
            if (x1 * x2 < 0.0)
                peakCounter++;
        }
    }
