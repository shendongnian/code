    public ActionResut MyView (int id)
      {
        var viewModel = new MyViewModel {ID = id};
        return View (viewModel);
      }
