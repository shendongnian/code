    // Model
    class TestModel
    {
         public string ContactId { get; set; }
    }
    
    //Controller
    [HttpPost]
    public ActionResult Edit(TestModel model)
    {
        string newId = model.ContactId;
    }
