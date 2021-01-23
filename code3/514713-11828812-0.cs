    public class Downloader
    {
    	public delegate void DownloadProgressHandler(object sender, string progress);
    	public event DownloadProgressHandler DownloadProgressChanged;
    
    	public static string progress;
    	public static int percent;
    	static WebClient client = new WebClient();
    	/// <summary>
    	/// Download a file from the internet
    	/// </summary>
    	/// <param name="url">The URL to download from</param>
    	/// <param name="path">The path to save to don't forget the / at the end</param>
    	/// <param name="filename">The filename of the file that is going to be download</param>
    	public string DownloadFile(string url, string path, string filename)
    	{
    		try
    		{
    			Thread bgThread = new Thread(() =>
    			{
    				client.DownloadProgressChanged += client_DownloadProgressChanged;
    				client.DownloadFileAsync(new Uri(url), path + filename);
    			});
    			bgThread.Start();
    		}
    		catch (Exception e)
    		{
    			Console.WriteLine(e.ToString());
    		};
    		return progress;
    	}
    
    	private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    	{
    		double bytesIn = double.Parse(e.BytesReceived.ToString(CultureInfo.InvariantCulture));
    		double totalBytes = double.Parse(e.TotalBytesToReceive.ToString(CultureInfo.InvariantCulture));
    		double percentage = bytesIn / totalBytes * 100;
    		progress = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
    		percent = int.Parse(Math.Truncate(percentage).ToString(CultureInfo.InvariantCulture));
    		while (client.IsBusy)
    		{
    			if (DownloadProgressChanged != null)
    				DownloadProgressChanged(this, progress);
    		}
    	}
    
    }
