    public class OrderViewModel
        {
            public int FavoriteMovieID { get; set; }
            public List<int> MovieIdsForMoviesILike { get; set; }
    
            public MovieCategories FavoriteMovieType { get; set; }
            public List<MovieCategories> MovieCategoriesILike { get; set; }
    
            public IEnumerable<SelectListItem> MoviesToSelectFrom 
            {
                get
                {
                    return from x in OrderDetailsRepo.GetAllMovies()
                           select new SelectListItem {
                               Text = x.Title,
                               Value = x.ID.ToString(),
                               Selected = MovieIdsForMoviesILike.Contains(x.ID),
                           };
                }
            }
    
            public IEnumerable<SelectListItem> MovieCategoriesToSelectFrom
            {
                get
                {
                    return from cat in Enum.GetValues(typeof(MovieCategories)).Cast<MovieCategories>()
                           select new SelectListItem {
                               Text = cat.ToString(),
                               Value = cat.ToString(),
                               Selected = MovieCategoriesILike.Contains(cat),
                           };
                }
            }
    
            public OrderViewModel()
            {
                // to ensure they are never NULL
                MovieIdsForMoviesILike = new List<int>();
                MovieCategoriesILike = new List<MovieCategories>();
            }
    }
    
    
