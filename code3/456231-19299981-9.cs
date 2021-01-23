    public class GoogleAnalyticsAPI
    {
        public AnalyticsService Service { get; set; }
        public GoogleAnalyticsAPI(ConnectionInfo info)
        {
            var initializer = GoogleAPIHelper.BuildServiceInitializer(info.PrivateKeyPath, info.ServiceAccountEmail,
                AnalyticsService.Scopes.Analytics.GetStringValue(), info.ApplicationName);
            Service = new AnalyticsService(initializer);
        }
        public AnalyticDataPoint GetAnalyticsData(string profileId, string[] demensions, string[] metrics, DateTime startDate, DateTime endDate)
        {
            AnalyticDataPoint data = new AnalyticDataPoint();
            if (!profileId.Contains("ga:"))
                profileId = string.Format("ga:{0}", profileId);
            //Make initial call to service.
            //Then check if a next link exists in the response,
            //if so parse and call again using start index param.
            GaData response = null;
            do
            {
                int startIndex = 1;
                if (response != null && !string.IsNullOrEmpty(response.NextLink))
                {
                    Uri uri = new Uri(response.NextLink);
                    var paramerters = uri.Query.Split('&');
                    string s = paramerters.First(i => i.Contains("start-index")).Split('=')[1];
                    startIndex = int.Parse(s);
                }
                var request = BuildAnalyticRequest(profileId, demensions, metrics, startDate, endDate, startIndex);
                response = request.Execute();
                data.ColumnHeaders = response.ColumnHeaders;
                data.Rows.AddRange(response.Rows);
            } while (!string.IsNullOrEmpty(response.NextLink));
            return data;
        }
        private DataResource.GaResource.GetRequest BuildAnalyticRequest(string profileId, string[] demensions, string[] metrics,
                                                                            DateTime startDate, DateTime endDate, int startIndex)
        {
            DataResource.GaResource.GetRequest request = Service.Data.Ga.Get(profileId, startDate.ToString("yyyy-MM-dd"),
                                                                                endDate.ToString("yyyy-MM-dd"), string.Join(",", metrics));
            request.Dimensions = string.Join(",", demensions);
            request.StartIndex = startIndex;
            return request;
        }
        public IList<Profile> GetAvailableProfiles()
        {
            var response = Service.Management.Profiles.List("~all", "~all").Execute();
            return response.Items;
        }
        public class AnalyticDataPoint
        {
            public AnalyticDataPoint()
            {
                Rows = new List<IList<string>>();
            }
            public IList<GaData.ColumnHeadersData> ColumnHeaders { get; set; }
            public List<IList<string>> Rows { get; set; }
        }
    }
