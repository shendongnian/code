    [HttpPost]
    public ActionResult Index(OrderViewModel model)
    {
        if (ModelState.IsValid)
        {
            foreach (var q in model.Courses)
            {
                var qId = q.ID;
                var selectedAnswer = q.SelectedAnswer;
                // Save the data 
            }
            return RedirectToAction("ThankYou"); //PRG Pattern
        }
        //to do : reload courses and options on model.
        return View(model);
    }
