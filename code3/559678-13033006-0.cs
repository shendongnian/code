    public class Movie
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
    public Movie Convert(string jsonString)
    {
        return JsonConvert.DeserializeObject<Movie>(jsonString);
    }
        
