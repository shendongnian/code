        public static void LoadYahooResults(string path)
        {
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
                        var results = doc.Descendants().FirstOrDefault(r => (r.Name.LocalName == "results")).Descendants();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle Exception
            }
        }
