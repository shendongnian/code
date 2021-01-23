    // NOTE: I do not know the actual types of these properties, YMMV
    public sealed class UrlHistoryList
    {
        public string Url { get; set; }
        public string UrlTitle { get; set; }
        public string UrlType { get; set; }
        public int Frequency { get; set; }
        public bool Active { get; set; }
        public DateTime LastChangeDate { get; set; }
        public DateTime LastCheckDate { get; set; }
        public DateTime DateRun { get; set; }
        public int HashValue { get; set; }
    }
    static public IEnumerable<UrlHistoryList> GetAllUrls()
            {
    
    
    
                using (MonitoredUrlsEntities mu = new MonitoredUrlsEntities())
                {
    
    
                    var query = from urlTbl in mu.UrlLists
                                join histTbl in mu.Histories on
                                urlTbl.ID equals histTbl.UrlID
                                select new UrlHistoryList
                                {
                                    Url = urlTbl.Url,
                                    UrlTitle = urlTbl.UrlTitle,
                                    UrlType = urlTbl.UrlType,
                                    Frequency = urlTbl.Frequency,
                                    Active = urlTbl.Active,
                                    LastChangeDate = urlTbl.LastChangeDate,
                                    LastCheckDate = urlTbl.LastCheckDate,
                                    DateRun = histTbl.DateRun,
                                    HashValue = histTbl.HashValue
                                };
    
                      return query.ToList();
    
    
                }
