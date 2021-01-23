    public ActionResult Add(Portfolio portfolio)
    {
        portfolio.Username = Session["Username"]; // or however the username is stored
        var ctx = new MarginEntities();
        ctx.Portfolios.Add(portfolio);
        ctx.SaveChanges();
        return RedirectToAction("Index");
    }
