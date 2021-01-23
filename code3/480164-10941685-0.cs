    var url = "http://ytcracker.com/music/";
    var sr = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream());
    string line;
    
    var re = new Regex(@"<li><a href=.*mp3.>(.*)</a></li>");
    
    while ((line = sr.ReadLine()) != null)
    {
    	using (var client = new WebClient())
    	{
    		if (re.IsMatch(line))
    		{
    			var match = re.Match(line);
    
    			client.DownloadFile("http://www.ytcracker.com/music/" + match.Groups[1], @"C:\Users\Lavi\Downloads\downloadto\.mp3");
    		}
    	}
    }
