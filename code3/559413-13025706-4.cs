     public class SiteSession
    {
        #region Attributes
        private static string _siteSession = "__SiteSession__";
        #endregion
        #region Constructor
        private SiteSession()
        {
        }
        #endregion
        #region CurrentSession
        public static SiteSession Current
        {
            get
            {
                SiteSession session = HttpContext.Current.Session[_siteSession ] as    SiteSession;
                if (session == null)
                {
                    session = new SiteSession();
                    HttpContext.Current.Session[_siteSession ] = session;
                }
                return session;
            }
        }
        #endregion
        #region SessionProperties
        public sherserve.CustomTypes.UserTypes UserType { get; set; }
        public int UserID { get; set; }
        public String StaffID { get; set; }
        public String Position { get; set; }
        public String StaffName { get; set; }
        public int TimeZone { get; set; }
        public String DealerId { get; set; }
        public String DealerPosition { get; set; }
        public String DealerName { get; set; }
        public int DealerFirmId { get; set; }
        public String ClientId { get; set; }
        public String ClientName { get; set; }
        public String ClientBusiness { get; set; }
        public String CountryCode { get; set; }
        public int ClientFirmId { get; set; }
        #endregion
    }
