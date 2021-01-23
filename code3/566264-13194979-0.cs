    public static IEnumerable<List<T>> SplitBy<T>(
        this IEnumerable<T> source, T delimiter)
    {
        List<T> buffer = new List<T>();
        var comparer = EqualityComparer<T>.Default;
        foreach (var item in source)
        {
            if (comparer.Equals(item, delimiter))
            {
                yield return buffer;
                buffer = new List<T>();
            }
            else
            {
                buffer.Add(item);
            }
        }
        yield return buffer;
    }
    static void Main()
    {
        List<double> values = new List<double> 
            {1.2,2.2,3.2,double.NaN,2.2,2.3,double.NaN,4.1,4.2,4.3 };
        List<List<double>> result = values.SplitBy(double.NaN).ToList();
    }
