	public partial class MovieInfo : IMovieInfo
	{
        ~~~~
		[JsonProperty("genres")]
		[JsonConverter(typeof(ListConverter<IGenre, Genre>))]
		public IList<IGenre> Genres { get; set; }
        ~~~~
    }
