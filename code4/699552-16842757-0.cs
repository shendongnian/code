    public ActionResult Index()
    {
        bool isUsersFirstTime = IsFirstTime(); // Do something to read this value from the database
        if (isUsersFirstTime)
        {
            UpdateFirstTimeFlag(); // Do something to update this value in the database
        }
        ViewBag.FirstTimeUser = isUsersFirstTime;
    }
