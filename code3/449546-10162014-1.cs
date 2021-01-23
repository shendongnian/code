    class Result
    {
      public GroupHeader Header {get;set;}
      public IEnumerable<Movie> Movies {get;set;}
    }
    public static Func<MovieDBContext, IQueryable<Result>> GetGroupHeadersWithMovies =
      CompiledQuery.Compile((MovieDBContext x) => 
          from m in x.Movies
          group m by m.GroupHeader into grp 
          select new Result
          {
            Movies = grp,
            Header = grp.Key
          });
