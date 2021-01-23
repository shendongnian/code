    public ActionResult Details(int id)
    {
        var myModel = GetMyModelData(id);
        string modelJson = JsonConvert.SerializeObject(product); 
        return View(modelJson);
    }
