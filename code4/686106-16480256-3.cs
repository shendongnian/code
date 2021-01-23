    public ViewResult Index(Profile_Ga profile_ga, Poste poste)
    {
        var viewModel = new MyViewModel();
        viewModel.MyPosts = db.Profil_Gas.ToList();
        viewModel.MyGames = db.Postes.ToList();
        return viewModel;
    }
