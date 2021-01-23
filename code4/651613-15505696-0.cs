    [HttpPost]
    public ActionResult YourAction(YourModel model)
    {
        String dataXml = "<Data>";
        dataXml += "<firstnamex>" + model.FirstName + "</firstnamex>";
        dataXml += "<lastnamex>" + model.LastName + "</lastnamex>";
        dataXml += "</Data>";
        // ...
        return View(model); // or redirect or whatever
    }
