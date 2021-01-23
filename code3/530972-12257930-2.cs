    public ActionResult Movie(int id)
    {
        var movieModel = context.Movies.GetById(id);
        return View(movieModel);
    }
    
