    public int ok_join(string gr, out string gash, out string groupId) 
    {
            ...................
            gash = Regex.Match(response, @"gash:""(?<id>[^""]+)""").Groups["id"].Value;
            groupId = Regex.Match(response, @"state:""smd=(?<id>[^""]+)""").Groups["id"].Value;
           ......................  
    }
    
    public bool ok_post(string gr, string gash, string groupId) 
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.site.ru/" + gash + "&stoud=" + groupId + "&");
        .........................  
    }
    
    public void go() 
    {
        while (true)
        {
            ........
                    string gash;
                    string groupId
    
                    int h = ok_join(gr, out gash, out groupId);
                    if (h == 0)
                        ok_post(gr, gash, groupId);
            .............
         } 
    }
