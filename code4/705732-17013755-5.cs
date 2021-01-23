    public class ChartDataRecord
    {
        public long date { get; set; }
        public string graph { get; set; }
        public int value { get; set; }
        public override bool Equals(object obj)
        {
            var o = (ChartDataRecord) obj;
            return o.date == date && o.graph == graph && o.value == value;
        }
    }
    ...
    static void Main(string[] args)
    {
        var data = new List<ChartDataRecord>
        {
            new ChartDataRecord { date = 1370563200000, graph = "g0", value = 70 },
            new ChartDataRecord { date = 1370563200000, graph = "g1", value = 60 },
            new ChartDataRecord { date = 1370563200000, graph = "g2", value = 100 },
            new ChartDataRecord { date = 1370563260000, graph = "g0", value = 71 },
            new ChartDataRecord { date = 1370563260000, graph = "g2", value = 110 },
            new ChartDataRecord { date = 1370563320000, graph = "g0", value = 72 },
            new ChartDataRecord { date = 1370563320000, graph = "g1", value = 62 },
            new ChartDataRecord { date = 1370563320000, graph = "g2", value = 150 }
        };
        var records = new ChartDataRecordCollection(data);
        var result = JsonConvert.SerializeObject(records);
        Console.WriteLine(result);
        var test = JsonConvert.DeserializeObject<ChartDataRecordCollection>(result);
        Console.WriteLine(records.SequenceEqual(test));
        Console.ReadLine();
    }
