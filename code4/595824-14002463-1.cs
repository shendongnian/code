    // grab information
    using (var wc = new WebClient()) {
        json = wc.DownloadString(url);
    }
    
    // deserialize using JSON.NET
    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ck[]>(json);
    
    // output
    foreach (var i in result)
    {
        lblTitle.Text = i.node_title;
        lblNid.Text = i.nid;
        imgCk.ImageUrl = i.main_image;}
    }
