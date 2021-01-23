    public ActionResult Delete(int id)
    {
        // Load subscription with given id from DB
        // and populate a `SubscriptionDeleteViewModel`.
        // It does not need to contain the related companies
        return View(viewModel);
    }
