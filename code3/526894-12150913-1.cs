    public static IEnumerable<double> RollingAverage(this IEnumerable<double> values, int count)
    {
        var queue = new Queue<double>();
        double sum = 0.0;
        foreach (var v in values)
        {
            sum += v;
            queue.Enqueue(v);
            if (queue.Count == count)
            {
                yield return sum / count;
                sum -= queue.Dequeue();
            }
        }
    }
