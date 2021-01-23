    List<Tuple<string, string>> list = new List<Tuple<string, string>>()
    {
        //Joe - Bob Mary - Bob Bob - Joe Mary - Joe Jack - Mary Joe - Bob
        new Tuple<string,string>("Joe","Bob"),
        new Tuple<string,string>("Mary","Bob"),
        new Tuple<string,string>("Bob","Joe"),
        new Tuple<string,string>("Mary","Joe"),
        new Tuple<string,string>("Jack","Mary"),
        new Tuple<string,string>("Joe","Bob")
    };
    var result = list.GroupBy(x=>x, new MyComparer())
        .Select(g=>new {Count = g.Count(),Pair = g.First()})
        .ToArray();
--
    public class MyComparer : IEqualityComparer<Tuple<string, string>>
    {
        public bool Equals(Tuple<string, string> x, Tuple<string, string> y)
        {
            return (x.Item1 == y.Item1 && x.Item2 == y.Item2) ||
                (x.Item2 == y.Item1 && x.Item1 == y.Item2);
        }
        public int GetHashCode(Tuple<string, string> obj)
        {
            return obj.Item1.GetHashCode() ^ obj.Item2.GetHashCode();
        }
    }
