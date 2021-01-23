    public ActionResult Index()
    {
        var viewModel = new PortfolioExtended();
        var currentUser = User.Identity.Name;
        var userGroupId = db.UserProfiles.Single(x => x.UserName == currentUser).GroupId;
        viewModel.Portfolios = db.Portfolios.Where(x => x.GroupID == userGroupId);
        return View(viewModel);
    }
