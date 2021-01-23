    public int FavoriteMovieID { get; set; }
    public IEnumerable<SelectListItem> MoviesToSelectFrom 
    {
        get
        {
            return from x in OrderDetailsRepo.GetAllMovies()
                    select new SelectListItem {
                        Text = x.Title,
                        Value = x.ID.ToString(),
                        Selected = x.id == this.FavoriteMovieID,
                    };
        }
    }
