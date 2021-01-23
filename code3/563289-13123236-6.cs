    public ActionResult StepOne()
    {
      return View(new StepOneViewModel());
    }
    [HttpPost]
    public ActionResult StepOne(StepOneViewModel model)
    {
      if(ModelState.IsValid)
      {
        var stepTwoModel = new StepTwoViewModel ()
        {
          StepOne = model
        };
        // Again, there's a bunch of different ways
        // you can handle flow between steps, just
        // doing it simply here to give an example
        return View("StepTwo", model);
      }
      return View(model);
    }
    [HttpPost]
    public ActionResult StepTwo(StepTwoViewModel model)
    {
      if (ModelState.IsValid)
      {
        // You could also add a method to the final ViewModel
        // to do this mapping, or use something like AutoMapper
        MyModel model = new MyModel()
        {
          Foo = model.StepOne.Foo
          Bar = model.Bar
        };
        this.Context.MyModels.Add(model);
        this.Context.SaveChanges();
      }
  
      return View(model);
    }
