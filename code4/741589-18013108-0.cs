    public ActionResult Save(MyViewModel viewModel) {
      if (!ModelState.IsValid)
        return View(viewModel);
      ... process a valid submission
    }
