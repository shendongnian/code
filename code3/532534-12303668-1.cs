    public class Category {
        public int Id {get;set;}
        public string Title {get;set;}
        public virtual IList<Report> ReportList {get;set;} //Navigation property
    }
