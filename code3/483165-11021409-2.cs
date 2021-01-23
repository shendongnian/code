    public class SomeInnerClass
    {
        public string Date { get; set; }
        public string Number { get; set; }
    }
    public class ScatterLineChartSeriesModel
    {                
        public string Name { get; set; }
        public IList<IList<SomeInnerClass>> Data { get; set; }        
    }
