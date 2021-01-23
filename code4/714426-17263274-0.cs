    var obj = JsonConvert.DeserializeObject<TmdbMovieAccountStates>(json);
            
    if (obj.Rated is Boolean)
        Console.WriteLine(obj.Rated);
    else
        Console.WriteLine(obj.Rated.value);
    public class TmdbMovieAccountStates 
    {
        public Int32 Id { get; set; }
        public Boolean Favorite { get; set; }
        public dynamic Rated { get; set; }
        public Boolean Watchlist { get; set; }
    }
