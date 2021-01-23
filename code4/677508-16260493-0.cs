    public void FireHashSearch()
            {
                //string searchQuery = string.Format(TWITTER_URL, "%23zesdaagsegent", _MaxSearchResultsCount);
                Uri searchQueryUri = new Uri(URI, UriKind.Absolute);
                searchTwitter = new WebClient();
    
                searchTwitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(searchTwitter_DownloadStringCompleted);
                searchTwitter.DownloadStringAsync(searchQueryUri);
            }
    
            public void searchTwitter_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
            {
    
    
                // Grab response.
                string results = e.Result;
                JObject o = JObject.Parse(results);
               // String naam = o.GetValue("text").ToString();
    
    
    
                JToken token = o["results"];
                JArray array =(JArray)(o["results"]);
    
              
    
                for (int i = 0; i < array.Count; i++)
                {
                    lstTwitter.ItemsSource = ItemsTwitter;
                    JToken test = JObject.Parse(array[i].ToString());
                    
                    // for(int i = 0; i<token.
                    // DataBind.
                    this.ItemsTwitter.Add(new Tweet()
                    {
                        
                        Avatar = "",
                        
                        Msg = (string)test.SelectToken("text"),
                        User = (string)test.SelectToken("from_user")
                    });
    
                }
    
    
            }
