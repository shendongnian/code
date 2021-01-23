    WebClient client = new WebClient();  
    using(var stream = client.OpenRead(" some link ")) {
        reader = new StreamReader(stream);   
        var jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());  
        var list = (from TReal obj in jObject["Some_stream"]
                   select ((string)obj["some_channel"]["some_name"])).ToList();
    }
