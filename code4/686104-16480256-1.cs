    public ViewResult Index(Profile_Ga profile_ga, Poste poste)
    {
        var viewModel = new MyViewModel();
        viewModel.MyPosts = new SelectList(db.Profil_Gas, "ID_Gamme", profile_ga.ID_Gamme);
        viewModel.MyGames = new SelectList(db.Postes, "ID_Poste", poste.ID_Poste);
        return viewModel;
    }
