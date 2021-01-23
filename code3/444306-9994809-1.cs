    public ActionResult Index()
    {
        var testModel = new TestModel();
        testModel.Fields = new List<Field>
                                {
                                    new Field { Key = "Choice 1" , Selected = true , Value = "1"},
                                    new Field { Key = "Choice 2" , Selected = false , Value = "2"},
                                    new Field { Key = "Choice 3" , Selected = false , Value = "3"}
                                };
        return View(testModel);
    }
    
    [HttpPost]
    public ActionResult XY(TestModel model)
    {
        var selectedFields = model.Fields.Where(f => f.Selected);
        /** Do some logic **/
        return View();
    }
