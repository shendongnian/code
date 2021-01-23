    [HttpPost]
    public ActionResult Create(FormCollection collection) //POST create for A
    {
        A a = new A();
        a.Name = collection["Name"];
        a.Description = collection["Description"];
        try
        {
            int bId = Int32.Parse(collection["B"]);
            a.B = db.B.First(option => option.Id == bId);
            ValidateModel(a);
        }
        catch
        {
            ModelState.AddModelError("B", new Exception("bId does not match an existing B"));
        }
        if (ModelState.IsValid)
        {
            db.A.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Failed
        //Go back to create form
        List<B> blist = db.B.ToList();
        ViewData["B"] = blist.Select(option => new SelectListItem
        {
            Text = (option.Name.ToString()),
            Value = (option.Id.ToString())
        });
        return View(a);
    }
