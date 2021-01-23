	//this method invokes another object that is responsible for making the 
    //http call, decompressing the file and persisting to the hard drive.
    private static void downloadFile(string url, string LocationToSave)
    {
        using (WeatherFactory wf = new WeatherFactory())
        {
            wf.getWeatherDataSource(url, LocationToSave);
        }
        //Update cache here?
    }
	private void StartBackgroundDownload()
	{
		//Things to consider:
		// 1. what if we are already downloading, start new anyway?
		// 2. when/how to update your cache
	    var task = Task.Factory.StartNew(_=>downloadFile(url, LocationToSave));
	}
