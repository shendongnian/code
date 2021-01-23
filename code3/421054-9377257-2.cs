        public static YahooQueryResult LoadYahooResults(string url)
        {
            YahooQueryResult result = null;
            WebRequest request = WebRequest.Create(path);
            request.Timeout = 5000;
            try
            {
                using (WebResponse response = request.GetResponse())
                {                                                                                        
                    XDocument doc = XDocument.Load(response.GetResponseStream());
                    if (doc != null)
                    {
                        var query = doc.Root;
                        // Query Attribute Values
                        var count = int.Parse(query.Attributes().First(c => c.Name.LocalName == "count").Value);
                        var created = query.Attributes().First(c => c.Name.LocalName == "created").Value;
                        var lang = query.Attributes().First(c => c.Name.LocalName == "lang").Value;
                        var results = doc.Descendants().FirstOrDefault(r => (r.Name.LocalName == "results")).Descendants().Select(a => new Result() { ID = int.Parse(a.Attribute("href").Value.Replace("/dir/index?sid=", string.Empty).Trim()), Href = a.Attribute("href").Value, Text = a.Value }).ToList();
                        result = new YahooQueryResult() { Lang = lang, Created = created, Count = count, Results = results };
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle Exception
            }
            return result;
        }
        public class Result
        {
            public int ID { get; set; }
            public string Href { get; set; }
            public string Text { get; set; }
        }
        public class YahooQueryResult
        {
            public string Lang { get; set; }
            public string Created { get; set; }
            public int Count { get; set; }
            public IEnumerable<Result> Results { get; set; }
            
        }
