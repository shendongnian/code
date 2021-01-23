    [HttpPost]
    public ActionResult Edit(MyModel myModel)
    {
        if (ModelState.IsValid)
        {
            var existEntry = _db.YourEntity.firstOrDefault(o => A == o.A);
            if(existEntry != null){
              existEntry.A = myModel.A;
              existEntry.B = myModel.B;
            }
            else{
              _db.YourEntity.Add(myModel);
            }
            _db.SaveChanges();
        }
        return View(myModel);
    }
