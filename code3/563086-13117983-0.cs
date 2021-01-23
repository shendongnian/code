    [HttpPost]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)//the state is always **invalid**
            {
                _db.Menus.Add(menu);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentMenuId = new SelectList(_db.Menus, "Id", "Name", menu.ParentMenuId);
            ViewBag.Roles = new SelectList(_db.UserRoles.ToList(), "Id", "Name");
            return View(menu);
        }
 
