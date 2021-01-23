    public ActionResult Index(int id)
    {
        var client = (from r in Clients
                     where r.ClientID == id
                     select r).SingleOrDefault();
        if (client != null)
        {
            return View(client);
        }
        return HttpNotFound();
     }
