    public ActionResult GetResults(List<Predicate<CTYPE>> predicates)
        {
        var results = _db.Categories
          .Where(c => predicates.All(pred => pred(c)))
          .Select(c => c.RootCat);
        return View();
        }
