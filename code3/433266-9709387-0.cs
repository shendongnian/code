    class Record // Changed from Records; each object is only a single record...
    {
        public string Name { get; set; }
        public int SomeValue { get; set; }
        public int OrderNumber { get; set; }
    }
    private static List<Record> ConvertRecords(IEnumerable<string> lines)
    {
        List<Record> records = new List<Record>();
        foreach (string line in lines)
        {
            string[] split = line.Split('|');
            Record record = new Record {
                Name = split[0],
                SomeValue = int.Parse(split[1]),
                OrderNumber = int.Parse(split[2]);
            };
            records.Add(record);
        }
    }
