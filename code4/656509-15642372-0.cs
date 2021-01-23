    public abstract class ReportLocationTree {
        public int id { get; set; }
    }
    
    public class ReportTree : ReportLocationTree {
        public string moreStuff { get; set; }
    }
    
    public class LocationTree : ReportLocationTree {
        public string evenMoreStuff { get; set; }
    }
    
    List<JsonTreeView> FromReportTree(List<ReportLocationTree> list)
    {
        list.Select(t => new JsonTreeView { id = t.id }).ToList();
    }
