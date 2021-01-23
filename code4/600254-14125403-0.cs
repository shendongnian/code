    private void SetViewBagCombo(int selectedValue = 0)
    {
       ViewBag.bs = new SelectList(getBobjects(), "Id", "CategoryDescription", selectedValue);
    }
    
    public ActionResult Create()
    {
       SetViewBagCombo(); 
       return View();   
    }
    
    [HttpPost]
    public ActionResult Create(A input)
    {
       if (ModelState.IsValid)
       {
          // persist it
          return RedirectToAction("Index");
       }
      
       SetViewBagCombo(input.B.Id); 
       return View();   
    }
