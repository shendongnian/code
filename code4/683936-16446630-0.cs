       HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri("https://api.twitter.com/1/statuses/user_timeline.json?screen_name=ScreenName"));
                string ApiResponse = await response.Content.ReadAsStringAsync();
                List<Tweet> tweets = await JsonConvert.DeserializeObjectAsync<List<Tweet>>(ApiResponse);
                _model.Tweets.Clear();
                foreach (var item in tweets)
                {
                    _model.Tweets.Add(new Tweet
                    {
                        Name = "@UserName",
                        Message = item.Text,
                        Image = new BitmapImage(new Uri("ms-appx:Assets/sampleLocalImage", UriKind.RelativeOrAbsolute)),
                    });
