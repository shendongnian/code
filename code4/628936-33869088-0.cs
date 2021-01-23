    public class WebLicenses
        {
            public int WebLicenseID { get; set; }
            public string WebLicenseName { get; set; }
            public int CustomerWebLicensesCount { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
        }
    public class WebApplication
    {
        public int appID { get; set; }
        public string WebApplicationName { get; set; }
        public int Count { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? EndDate { get; set; }
        public bool Never { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class griddetail
    {
        public griddetail(List<WebLicenses> wl1, List<WebApplication> wa1)
        {
            weblicences = wl1;
            webapplication = wa1;
        }
        public List<WebLicenses> weblicences { get; set; }
        public List<WebApplication> webapplication { get; set; }        
    }
