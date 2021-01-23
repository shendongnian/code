    protected void Page_Load(object sender, EventArgs e)
        {
             if(!IsPostBack)
             {
               movieId = Int32.Parse(Request.QueryString["id"]);
               Movie movie = MovieAccess.GetMovieDetails(movieId);
               startVideo(movie);    
             }  
        }
