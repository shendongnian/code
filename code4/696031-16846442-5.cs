    public ActionResult Index()
    {
        DelayedAction.ExecuteIfNeeded(updateNews);
        //All code below this commenting needs to run everytime a user visits the view
        ....
    }
