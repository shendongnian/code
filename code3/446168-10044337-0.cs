    //same code as in the example
    SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
    //I pull out the distinct list of categories from the entire feed
    //You might want to bind this list to a dropdown on your app
    //so that users can select what they want to see:
    List<string> cats = new List<string>();
    foreach (SyndicationItem si in feed.Items)
        foreach(SyndicationCategory sc in si.Categories)
           if (!cats.Contains(sc.Name))
              cats.Add(sc.Name);
    //Here I imagined that I want to see all items categorized as "Trendy"
    SyndicationCategory lookingFor = new SyndicationCategory("Trendy");
    //and I create a container where I could copy all "Trendy" items:
    List<SyndicationItem> coll = new List<SyndicationItem>();
    //And then I start filtering all items by the selected tag:
    foreach (SyndicationItem si in feed.Items)
    {
         foreach (SyndicationCategory sc in si.Categories)
             if (sc.Name == lookingFor.Name)
             {
                        coll.Add(si);
                        break;
             }
    }
           
    Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        // Bind the filtered of SyndicationItems to our ListBox.
           feedListBox.ItemsSource = coll;
           loadFeedButton.Content = "Refresh Feed";
    });
