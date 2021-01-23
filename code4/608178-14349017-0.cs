    public ActionResult Create()
        {
            Cat ca= new Cat();
    
            IEnumerable<SelectListItem> items = ca.Categories().Select(c => new SelectListItem
            {
                Text = c.name,
                Value = c.id.ToString()
            });
            ViewData["Categ"] = items;
    
            return View("Index");
        }
    [HttpPost]
    public ActionResult Create(BookEntity ent)
        {   
            db.BookEntity.Add(ent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
