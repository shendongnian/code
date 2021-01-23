    using (WebClient wc = new WebClient())
    {
        string json = wc.DownloadString("http://moon.eastlink.com/~jandrews/webservice2.php");
        var jObj = JObject.Parse(json);
        var items = jObj.Children()
                    .Cast<JProperty>()
                    .Select(c => new
                    {
                        Title = (string)c.Value["{\"Title"],
                        Body = (string)c.Value["Body"],
                        Caption = (string)c.Value["Caption"],
                        Datestamp = (string)c.Value["Datestamp"],
                    })
                    .ToList();
    }
