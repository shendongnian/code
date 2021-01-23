    [HttpGet]
    public ActionResult Index(Profile_Ga profile_ga, Poste poste)
    {
        var viewModel = new MyViewModel();
        viewModel.Profile_Gas = db.Profil_Gas.ToList();
        viewModel.Postes = db.Postes.ToList();
        return viewModel;
    }
    [HttpPost]
    public ActionResult Index(MyViewModel viewModel)
    {
        string debug = string.Format("You selected Profile: {0} and Poste: {1}", viewModel.SelectedProfile_Ga, viewModel.SelectedPoste);
        return View(viewModel);
    }
