    public class ProductReportView
    {
        public int Count { get; set; }
        public string ProductCode { get; set; }
        public string ProductTitle { get; set; }
        public string Producer { get; set; }
        public bool VideoOnDemand { get; set; }
        public bool PreviewScreen { get; set; }
        public bool QualityCheck { get; set; }
        public bool Archive { get; set; }
        private string toYesNo(bool b)
        {
            return b ? "Yes" : "No";
        }
        public string VideoOnDemandString
        {
            get { return this.toYesNo(this.VideoOnDemand); }
        }
        public string PreviewScreenString
        {
            get { return this.toYesNo(this.PreviewScreen); }
        }
        public string QualityCheckString
        {
            get { return this.toYesNo(this.QualityCheck); }
        }
        public string ArchiveString
        {
            get { return this.toYesNo(this.Archive); }
        }
    }
