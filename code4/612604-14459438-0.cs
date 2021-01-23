    public class movie: ICloneable
    {
        public string movieName { get; set; }
        public string movieYear { get; set; }
        public int movieYearInt { get { return int.Parse(movieYear) set {movieYear = value.ToString()}}
    
        public object Clone()
        {
            return new movie() {movieName = this.movieName, movieYear = this.movieYear};
        }
    }
    
    var m = new movie();
    m.movieYear = "2001";
    var newMovie = (movie) m.Clone();
