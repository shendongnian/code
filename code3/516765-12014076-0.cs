    SyndicationFeed feed = null;
           
           SyndicationClient client = new SyndicationClient();
           var feedUri = new Uri(myUri);
           try {
               var task = client.RetrieveFeedAsync(feedUri).AsTask();
               task.ContinueWith((x) => {
                   var result = x.Result;
                   Parallel.ForEach(result.Items, item => {
                       Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                       {
                           test.Text += item.Title.Text;
                       });
                   });
                   
                        
               });
           }
           catch (Exception ex) { }
