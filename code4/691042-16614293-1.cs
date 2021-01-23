    public class ReportModel
    {
        public int CategoryOneSeverity;
        public int CategoryTwoSeverity;
        public string Title;
    }   
    
    public class ReportClass : ReportModel
    {
        public int RiskRating
        { 
            get { return CategoryOneSeverity + CategoryTwoSeverity; }
        }
    }
