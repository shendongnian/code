               var subscriptionsUrl = 
                 "http://gdata.youtube.com/feeds/api/users/warmthonthesoul/subscriptions";
                var settings = new YouTubeRequestSettings([...]);
                var request = new YouTubeRequest(settings);
    
                var query = new YouTubeQuery(subscriptionsUrl);
                var feed = request.GetSubscriptionsFeed("warmthonthesoul").Entries;
    
                var itemToRemove = feed.SingleOrDefault(x =>
                                             x
                                             .SubscriptionEntry
                                             .Title.Text.Contains("Triforcefilms"));
    
                if(itemToRemove != null)
                {
                    itemToRemove.AtomEntry.EditUri = itemToRemove
                                                        .SubscriptionEntry
                                                        .EditUri;
                    request.Delete(itemToRemove);
                    Console.WriteLine("Item removed");
                }
    
                Console.ReadLine();
            }
