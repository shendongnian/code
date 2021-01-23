    public BindingList<Movie> SearchByTitle(Expression<Func<Movie, bool>> predicate)
    {
        var matches = movies.Where(predicate);
        // Do common stuff with the matches.
    }
