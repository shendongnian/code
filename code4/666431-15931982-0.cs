    public static volatile string picturesDownloaded = "0";
    System.Threading.Timer timer = new System.Threading.Timer(sendData, new Func<string>(() => picturesDownloaded), 1000 * 5, 1000 * 5);
    
    public static void sendData(object obj)
    {
        var value = ((Func<string>)obj)();
        WebClient wc = new WebClient();
        string imageCountJson = wc.DownloadString("http://******/u.php?count=" + value);
    }
