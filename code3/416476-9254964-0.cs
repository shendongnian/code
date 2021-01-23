    class MovieCollection {
            public IEnumerable<Movie> movies { get; set; }
    }
    
    class Movie {
            public string title { get; set; }
    }
    
    class Program {
            static void Main(string[] args)
            {
                    string jsonString = @"{""movies"":[{""id"":""1"",""title"":""Sherlock""},{""id"":""2"",""title"":""The Matrix""}]}";
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    MovieCollection collection = serializer.Deserialize<MovieCollection>(jsonString);
            }
    }
