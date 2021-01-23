    public ActionResult Index()
    {
        YourDBContext db = new YourDBContext();
        IEnumerable<ExampleModel> model = db.GetDataFromDatabase();
        return View(model); // Pass the model to the view
    }
