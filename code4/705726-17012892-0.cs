    public class StackOverflow_17012831
    {
        public class ChartDataRecord
        {
            public long date { get; set; }
            public string graph { get; set; }
            public int value { get; set; }
        }
        public static void Test()
        {
            List<ChartDataRecord> data = new List<ChartDataRecord>();
            data.Add(new ChartDataRecord { date = 1370563200000, graph = "g0", value = 70 });
            data.Add(new ChartDataRecord { date = 1370563200000, graph = "g1", value = 60 });
            data.Add(new ChartDataRecord { date = 1370563200000, graph = "g2", value = 100 });
            data.Add(new ChartDataRecord { date = 1370563260000, graph = "g0", value = 71 });
            data.Add(new ChartDataRecord { date = 1370563260000, graph = "g2", value = 110 });
            data.Add(new ChartDataRecord { date = 1370563320000, graph = "g0", value = 72 });
            data.Add(new ChartDataRecord { date = 1370563320000, graph = "g1", value = 62 });
            data.Add(new ChartDataRecord { date = 1370563320000, graph = "g2", value = 150 });
            var obj = new { data = data, name = "Name" };
            string str = JsonConvert.SerializeObject(obj);
            Console.WriteLine(str);
        }
    }
