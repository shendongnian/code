    private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SyndicationFeed feed = null;
    
            SyndicationClient client = new SyndicationClient();
            Uri feedUri = new Uri(myUri);
    
            try
            {
                feed = await client.RetrieveFeedAsync(feedUri);
    
                foreach (var item in feed.Items)
                {       
                    test.Text += item.Summary.Text + Environment.NewLine;                    
                }
            }
            catch
            {
                test.Text += "Connection failed\n";
            }
        }
