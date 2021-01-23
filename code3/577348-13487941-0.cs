    public static IEnumerable<float> RunningSum(this IEnumerable<float> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(source);
        }
        float sum = 0f;
        foreach (var item in source)
        {
            sum += item;
            yield return sum;
        }
    }
