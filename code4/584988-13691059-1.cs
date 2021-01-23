    public JoinResults ok_join(string gr)
    {
        string gash = "";
        string groupID = "";
        //...
        return new JoinResults()
        {
            H = 0,
            Gash = gash,
            GroupId = groupID,
        };
    }
    
    public bool ok_post(string gr, JoinResults joinResults)
    {
        string url = "http://www.site.ru/" + joinResults.Gash + "&stoud="
            + joinResults.GroupId + "&";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //.........................
        return true;
    }
