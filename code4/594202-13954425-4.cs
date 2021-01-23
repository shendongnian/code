    [DataContract]
    public class ChartModel{
     [DataMember(Name = "chart.labels")]
     public string[] Labels {get;set;}
     [DataMember(Name = "chart.tooltips")]
     public string[] Tooltips {get;set;}
    }
