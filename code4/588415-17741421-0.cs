    [HttpPost]
    public ActionResult Update(string json)
    {
        // this line convert the json to a list of your type, exactly what you want.
        IList<CustomTypeModel> ctm = 
             new JavaScriptSerializer().Deserialize<IList<CustomTypeModel>>(json);
        return RedirectToAction("Index");
    }
