    public class ChartLoc
    {
        public string Category { get; set; }
        public List<int> Data { get; set; }
    }
    ...
    var chartLocs = new List<ChartLoc>();
    chartLocs.Add(new ChartLoc { Category = "comA", Data = new List<int> { 1, 2, 3 } });
    chartLocs.Add(new ChartLoc { Category = "comB", Data = new List<int> { 4, 5, 6 } });
    chartLocs.Add(new ChartLoc { Category = "comC", Data = new List<int> { 7, 8, 9 } });
    
    JavaScriptSerializer jss = new JavaScriptSerializer();
    var json = jss.Serialize(chartLocs);
