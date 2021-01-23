    public static List<T> RandomlyChooseItems<T>(IEnumerable<T> items, int n, Random rng)
    {
        var result = new List<T>(n);
        int index = 0;
        foreach (var item in items)
        {
            if (index < n)
            {
                result.Add(item);
            }
            else
            {
                int r = rng.Next(0, index + 1);
                if (r < n)
                    result[r] = item;
            }
            ++index;
        }
        return result;
    }
