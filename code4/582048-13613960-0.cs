	public List<MovieDirector> GetDirectorsPossibleForMovie(
		int MovieID, List<Director> director)
	{
		List<MovieDirector> directors =
			(from item in db.MovieDirectors
			where item.MovieId != MovieID
			orderby item.Director.Lastname
			select item)
			.Except(director)
			.ToList<MovieDirector>();
		return directors;
	}
