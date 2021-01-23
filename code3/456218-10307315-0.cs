    namespace Utilities.Google
    {
        public class Analytics
        {
            private readonly String ClientUserName;
            private readonly String ClientPassword;
            private readonly String TableID;
            private AnalyticsService analyticsService;
    
            public Analytics(string user, string password, string table)
            {
                this.ClientUserName = user;
                this.ClientPassword = password;
                this.TableID = table;
    
                // Configure GA API.
                analyticsService = new AnalyticsService("gaExportAPI_acctSample_v2.0");
                // Client Login Authorization.
                analyticsService.setUserCredentials(ClientUserName, ClientPassword);
            }
    
            /// <summary>
            /// Get the page views for a particular page path
            /// </summary>
            /// <param name="pagePath"></param>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <param name="isPathAbsolute">make this false if the pagePath is a regular expression</param>
            /// <returns></returns>
            public int GetPageViewsForPagePath(string pagePath, DateTime startDate, DateTime endDate, bool isPathAbsolute = true)
            {
                int output = 0;
    
                // GA Data Feed query uri.
                String baseUrl = "https://www.google.com/analytics/feeds/data";
    
                DataQuery query = new DataQuery(baseUrl);
                query.Ids = TableID;
                //query.Dimensions = "ga:source,ga:medium";
                query.Metrics = "ga:pageviews";
                //query.Segment = "gaid::-11";
                var filterPrefix = isPathAbsolute ? "ga:pagepath==" : "ga:pagepath=~";
                query.Filters = filterPrefix + pagePath;
                //query.Sort = "-ga:visits";
                //query.NumberToRetrieve = 5;
                query.GAStartDate = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                query.GAEndDate = endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                Uri url = query.Uri;
                DataFeed feed = analyticsService.Query(query);
                output = Int32.Parse(feed.Aggregates.Metrics[0].Value);
    
                return output;
            }
    
            public Dictionary<string, int> PageViewCounts(string pagePathRegEx, DateTime startDate, DateTime endDate)
            {
                // GA Data Feed query uri.
                String baseUrl = "https://www.google.com/analytics/feeds/data";
    
                DataQuery query = new DataQuery(baseUrl);
                query.Ids = TableID;
                query.Dimensions = "ga:pagePath";
                query.Metrics = "ga:pageviews";
                //query.Segment = "gaid::-11";
                var filterPrefix = "ga:pagepath=~";
                query.Filters = filterPrefix + pagePathRegEx;
                //query.Sort = "-ga:visits";
                //query.NumberToRetrieve = 5;
                query.GAStartDate = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                query.GAEndDate = endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                Uri url = query.Uri;
                DataFeed feed = analyticsService.Query(query);
    
                var returnDictionary = new Dictionary<string, int>();
                foreach (var entry in feed.Entries)
                    returnDictionary.Add(((DataEntry)entry).Dimensions[0].Value, Int32.Parse(((DataEntry)entry).Metrics[0].Value));
    
                return returnDictionary;
            }
        }
    }
