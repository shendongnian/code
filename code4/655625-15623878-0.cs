    [HttpPost]
    public ActionResult Create(CHAMADOS chamados)
    {
        if (ModelState.IsValid)
        {
            chamados.CreatedDate = DateTime.Now;
            db.CHAMADOS.Add(chamados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(chamados);
    }
