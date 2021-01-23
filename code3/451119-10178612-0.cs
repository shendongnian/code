    // prepare data
    double[] values = new double[20];
    for (int i = 0; i < values.Length; i++)
    {
        values[i] = 40.0;
    }
    // get the original total
    double originalTotal = 0.0;
    for (int i = 0; i < values.Length; i++)
    {
        originalTotal += values[i];
    }
    // specify an abberation percentage
    double x = 0.05;
    // jitter each value +/- the abberation percentage
    // also capture the total of the jittered values
    Random rng = new Random();
    double intermediateTotal = 0.0;
    for (int i = 0; i < values.Length; i++)
    {
        values[i] += values[i] * (rng.NextDouble() - 0.5) * (2.0 * x);
        intermediateTotal += values[i];
    }
    // calculate the difference between the original total and the current total
    double remainder = originalTotal - intermediateTotal;
    // add a flat amount to each value to make the totals match
    double offset = remainder / values.Length;
    for (int i = 0; i < values.Length; i++)
    {
        values[i] += offset;
    }
    // calculate the final total to verify that it matches the original total
    double finalTotal = 0.0;
    for (int i = 0; i < values.Length; i++)
    {
        finalTotal += values[i];
    }
