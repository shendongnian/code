    public static IEnumerable<double> RollingAverage(this IEnumerable<double> values, int count)
    {
        var queue = new Queue<double>();
        foreach (var v in values)
        {
            queue.Enqueue(v);
            if (queue.Count == count)
            {
                yield return queue.Average();
                queue.Dequeue();
            }
        }
    }
