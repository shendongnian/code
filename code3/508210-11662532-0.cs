    class JObjectReturned {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Website { get; set; }
    }
    
    public static JObjectReturned responseinfo(string url)
    {
        var client = new WebClient();
        client.Headers.Add("User-Agent", "Nobody");
        var response = client.DownloadString(new Uri(url));
        var responsestring = response.ToString();
        JObject o = JObject.Parse(responsestring);
        return new JObjectReturned() { 
            Id = (int)o["Id"],
            Name = (string)o["Name"],
            Category = (string)o["Category"],
            Price = (float)o["Price"],
            Website = (string)o["Website"]
        };
    }
