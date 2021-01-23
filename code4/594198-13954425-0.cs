    [DataContract]
    public class chart{
     [DataMember(Name = "chart.labels")]
     public string[] chartlabels {get;set;}
     [DataMember(Name = "chart.tooltips")]
     public string[] charttooltips {get;set;}
    }
