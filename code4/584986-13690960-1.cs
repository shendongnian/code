    public JoinResults ok_join(string gr)
    {
    		string gash = Regex.Match(response, @"gash:""(?<id>[^""]+)""").Groups["id"].Value;
    		string groupId = Regex.Match(response, @"state:""smd=(?<id>[^""]+)""").Groups["id"].Value;
    		
    		return new JoinResults(0, gash, groupId);
    }
    
    public bool ok_post(JoinResults joinResults, string gr)
    {
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.site.ru/" + joinResults.gash + "&stoud=" + joinResults.groupId + "&");
    }
    
    public void go()
    {
    	while (true)
    	{
    		JoinResults results = ok_join(gr);
    		if (results.h == 0)
    			ok_post(results, gr);
    	 }
    }
