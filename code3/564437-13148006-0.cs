    namespace ConsoleApplication3
    {
    class Program
    {
        internal class PiData
        {
            public string HeaderName { get; set; }
            public DateTime TimeStamp { get; set; }
            public DateTime End { get; set; }
            public double Value { get; set; }
        }
        static void Main(string[] args)
        {
            var PD = new List<PiData>()
            {
                new PiData() { HeaderName="Test1", End = DateTime.Now.AddSeconds(15), TimeStamp = DateTime.Now, Value = 0.01 },
                new PiData() { HeaderName="Testf2", End = DateTime.Now.AddSeconds(15), TimeStamp = DateTime.Now, Value = 0.51 },
                new PiData() { HeaderName="Testff3", End = DateTime.Now.AddSeconds(15), TimeStamp = DateTime.Now, Value = 0.71 },
                new PiData() { HeaderName="Testfsd4", End = DateTime.Now.AddSeconds(15), TimeStamp = DateTime.Now, Value = 0.41 },
                new PiData() { HeaderName="Test1", End = DateTime.Now.AddSeconds(30), TimeStamp = DateTime.Now.AddSeconds(15), Value = 0.01 },
                new PiData() { HeaderName="Testf2", End = DateTime.Now.AddSeconds(30), TimeStamp = DateTime.Now.AddSeconds(15), Value = 0.51 },
                new PiData() { HeaderName="Testff3", End = DateTime.Now.AddSeconds(30), TimeStamp = DateTime.Now.AddSeconds(15), Value = 0.71 },
                new PiData() { HeaderName="Testfsd4", End = DateTime.Now.AddSeconds(30), TimeStamp = DateTime.Now.AddSeconds(15), Value = 0.41 },
            };
  
        var result2 = PD.Pivot(emp => emp.TimeStamp, emp2 => emp2.HeaderName, lst => lst.Sum(a => a.Value));
        StringBuilder sb = new StringBuilder();
        List<string> columns = new List<string>();
        columns.Add("TimeStamp");
        columns.Add("End");
        foreach (var item in PD.Select(a => a.HeaderName).Distinct())
        {
            columns.Add(item);
        }
        foreach (var item in columns)
        {
            sb.Append(item + ",");
        }
        sb.Remove(sb.Length - 1, 1);
        sb.AppendLine();
        foreach (var row in result2)
        {
            sb.Append(row.Key + "," + row.Key.AddSeconds(10).ToString() + ",");
            foreach (var column in row.Value)
            {
                sb.Append(column.Value + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
        Console.WriteLine("----"); 
    
        }
    }
    public static class LinqExtenions
    {
        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TFirstKey> firstKeySelector, Func<TSource, TSecondKey> secondKeySelector, Func<IEnumerable<TSource>, TValue> aggregate)
        {
            var retVal = new Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>();
            var l = source.ToLookup(firstKeySelector);
            foreach (var item in l)
            {
                var dict = new Dictionary<TSecondKey, TValue>();
                retVal.Add(item.Key, dict);
                var subdict = item.ToLookup(secondKeySelector);
                foreach (var subitem in subdict)
                {
                    dict.Add(subitem.Key, aggregate(subitem));
                }
            }
            return retVal;
        }
    }
    }
