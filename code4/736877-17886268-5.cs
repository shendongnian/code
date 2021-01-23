    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	var coll = mainGrid.FindResource("tweets") as Tweets;
    	if (coll != null)
    	{
    		coll.Add(new Tweet("user", "name", "url"));
    	}
    }
