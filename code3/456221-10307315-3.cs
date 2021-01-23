    namespace Utilities
    {
        public interface IPageViewCounter
        {
            int GetPageViewCount(string relativeUrl, DateTime startDate, DateTime endDate, bool isPathAbsolute = true);
            Dictionary<string, int> PageViewCounts(string pagePathRegEx, DateTime startDate, DateTime endDate);
        }
    
        public class GooglePageViewCounter : IPageViewCounter
        {
            private string GoogleUserName
            {
                get
                {
                    return ConfigurationManager.AppSettings["googleUserName"];
                }
            }
    
            private string GooglePassword
            {
                get
                {
                    return ConfigurationManager.AppSettings["googlePassword"];
                }
            }
    
            private string GoogleAnalyticsTableName
            {
                get
                {
                    return ConfigurationManager.AppSettings["googleAnalyticsTableName"];
                }
            }
    
            private Analytics analytics;
    
            public GooglePageViewCounter()
            {
                analytics = new Analytics(GoogleUserName, GooglePassword, GoogleAnalyticsTableName);
            }
    
            #region IPageViewCounter Members
    
            public int GetPageViewCount(string relativeUrl, DateTime startDate, DateTime endDate, bool isPathAbsolute = true)
            {
                int output = 0;
                try
                {
                    output = analytics.GetPageViewsForPagePath(relativeUrl, startDate, endDate, isPathAbsolute);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
    
                return output;
            }
    
            public Dictionary<string, int> PageViewCounts(string pagePathRegEx, DateTime startDate, DateTime endDate)
            {
                var input = analytics.PageViewCounts(pagePathRegEx, startDate, endDate);
                var output = new Dictionary<string, int>();
    
                foreach (var item in input)
                {
                    if (item.Key.Contains('&'))
                    {
                        string[] key = item.Key.Split(new char[] { '?', '&' });
                        string newKey = key[0] + "?" + key.FirstOrDefault(k => k.StartsWith("p="));
    
                        if (output.ContainsKey(newKey))
                            output[newKey] += item.Value;
                        else
                            output[newKey] = item.Value;
                    }
                    else
                        output.Add(item.Key, item.Value);
                }
                return output;
            }
    
            #endregion
        }
    }
