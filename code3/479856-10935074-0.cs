    public class BuildReportViewModel
    {
        public IList<BuildReportFieldItemViewModel> Fields { get; set; }
    }
    public class BuildReportFieldItemViewModel
    {
        public string Field;
        public string Key;
    }
