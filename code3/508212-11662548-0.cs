    public class ProductDTO
    {
        public ProductDTO(string SourceURI)
        {
            this.SourceURI = SourceURI;
        }
        public void GetReady()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Nobody");
            var response = client.DownloadString(new Uri(this.SourceURI));
            var responsestring = response.ToString();
            JObject o = JObject.Parse(responsestring);
            this.Id = (int)o["Id"];
            this.Name = (string)o["Name"];
            this.Category = (string)o["Category"];
            this.Price = (float)o["Price"];
            this.Website = (string)o["Website"];
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public float Price { get; private set; }
        public string Website { get; private set; }
        public string SourceURI { get; private set; }
    }
