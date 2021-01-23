    [ChildActionOnly]
    public ActionResult tocourse()
    {
    courseviewModel model = new courseviewModel();
        return PartialView(model);
    }
