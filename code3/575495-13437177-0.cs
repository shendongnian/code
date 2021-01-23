    public ActionResult Index()
    {
        IEnumerable<ExampleModel> model = db.GetDataFromDatabase();
        return View(model); // Pass the model to the view
    }
