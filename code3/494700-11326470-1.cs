    public ActionResult MyPageView()
    {
        MyClassModel model = new MyClassModel(); // Single entity, strongly-typed
        // IList model = new List<MyClassModel>(); // or List, strongly-typed
        // ViewBag.MyHiddenInputValue = "Something to pass"; // ...or using ViewBag
        return View(model);
    }
