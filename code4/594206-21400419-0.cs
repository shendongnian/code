    public class ChartModel{
        [JsonProperty("chart.labels")]
        public string[] Labels {get;set;}
        [JsonProperty("chart.tooltips")]
        public string[] Tooltips {get;set;}
    }
