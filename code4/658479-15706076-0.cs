    public class MeterReadingsChartData
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string Unit { get; set; }
        public List<Tuple<DateTime, double>> DateAndValue { get; set; }
        public MeterReadingsChartData(string name, List<Tuple<DateTime, double>> dateAndValue, string typeName, string unit)
        {
            this.Name = name;
            this.DateAndValue = dateAndValue;
            this.TypeName = typeName;
            this.Unit = unit;
        }
    }
