    protected void Application_Start(object sender, EventArgs e)
    {
        var container = this.AddUnity();
        container.RegisterType<IPopularMovie, MovieManager>();
        container.RegisterType<IMovieRepository, XmlMovieRepository>();
    }
