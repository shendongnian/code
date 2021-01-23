    public static List<mycapsule<int, double>> sample = new List<mycapsule<int, double>>();
    public static void Main(string[] args)
    {
        sample.Add(new mycapsule<int, double> { id = 1, value = 1.2 });
        update(pred, 12.5, sample);
    }
    public static bool pred(double x)
    {
        if (x == 2.5) return true;
        return false;
    }
    public class mycapsule<KT, T>
    {
        public KT id { get; set; }
        public T value { get; set; }
        public int p; // and more
    }
    public static bool update<T>(Func<T, bool> predicate, T i, List<mycapsule<int, T>> list)
    {
        foreach (var x in list.FindAll(item => predicate(JustValue(item))))
        {
            x.value = i;
        }
        return true;
    }
    public static T JustValue<T>(mycapsule<int, T> i)
    {
        return i.value;
    }
