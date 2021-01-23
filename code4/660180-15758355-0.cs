    private ActionResult Admin()
    {
        var aux=db.UserMessages.ToList();
        return View(aux);         
    }
    public ActionResult Admin(int id = 0)
    {
        if (id == 0)
			return Admin();
      	var aux = db.UserMessages.ToList();
        return View(aux);
    }
