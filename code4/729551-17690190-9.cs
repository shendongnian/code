    public HomeController : MyBaseController
    {
      public ActionResult Index()
      {
        var viewModel = new MyViewModel();
        return this.ViewOrAjax(viewModel);
      }
    }
