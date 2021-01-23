    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string selected = String.Empty;
    
            //check to see if the selected parameter was passed.
            if (NavigationContext.QueryString.ContainsKey("selected"))
            {
                //get the selected parameter off the query string from MainPage.
                selected = NavigationContext.QueryString["selected"];
            }
    
            //did the querystring indicate we should go to item2 instead of item1?
            if (selected == "item2")
            {
                //item2 is the second item, but 0 indexed. 
                myPanorama.DefaultItem = myPanorama.Items[1];
            }
            base.OnNavigatedTo(e);
        }
