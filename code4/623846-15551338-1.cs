     public static class OrderDetailsRepo
            {
                public static List<Movie> GetAllMovies()
                {
                    return new List<Movie> {
                        new Movie { ID = 0, Title = "Great Expectation" },
                        new Movie { ID = 1, Title = "Gone with the Wind" },
                        new Movie { ID = 2, Title = "Lion of Winter" },
                    };
                }
            }
        
        public class Movie
            {
                public string Title { get; set; }
                public int ID { get; set; }
            }
        
        public enum MovieCategories
            {
                Horror,
                Drama,
                Comedy,
            }
