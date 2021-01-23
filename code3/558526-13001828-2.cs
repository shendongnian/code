    class GifCollection : ObservableCollection<Uri> {
	}
 
    // in the view
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    	var gifs = new GifCollection();
    				
    	gifs.Add(new Uri("http://i.imgur.com/eoNiq.gif"));
    	gifs.Add(new Uri("ms-appx-web:///Assets/spiral.gif"));
    					
    	this.DataContext = gifs;
    
    }
