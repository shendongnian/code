    //Get an Instance of Wordpress Controller (Singleton)
                    WordPressFeedController wp = WordPressFeedController.Instance;
                    //Load all the RSS Articles
                    wp.LoadRSS("http://www.its-all-about.de/rss");
                    //Get the Newest Article (Check Docs for other functions)
                    var rssItem = wp.GetNewestItem();
                    this.label1.Text = rssItem.Title;
                    //Text Only, Remove all the HTML Tags - Limit too 300 Chars
                    this.richTextBox1.Text = wp.RemoveHTMLFromText(rssItem.Summary.Substring(0, 300)) + "...";
                    //Open RSS Article on Button Click
                    this.button1.Click += (s, e) => {
                        Process.Start(rssItem.Id);
                    };
