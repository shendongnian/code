    private Task<double> JobAsync(double value)
    {
        return Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 30000000; i++)
                value += Math.Log(Math.Sqrt(Math.Pow(value, 0.75)));
            return value;
        });
    }
