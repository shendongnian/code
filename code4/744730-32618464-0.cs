    public ActionResult SomeAction(int id)
    {
        try
        {            
            var model = getMyModel(id);
            return View(model);
        }
        catch(Exception e)
        {
            var NotFoundViewModel = new NotFoundViewModel { Some Properties };
            return View("Error", NotFoundViewModel);
        }
    }
