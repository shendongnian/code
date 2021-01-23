	public static Dictionary<string, object> FilterMovie(MovieResponse movie, string[] fields)
	{
		var data = new Dictionary<string, object>();
		var movieType = movie.GetType();
	
		foreach (var field in fields)
		{
			data.Add(field, movieType.GetField(field).GetValue(movie));
		}
	
		return data;
	}
