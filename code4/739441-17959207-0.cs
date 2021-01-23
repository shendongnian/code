    [HttpGet]
    public ActionResult AdvocateEdit(int id)
    {
       try
       {
           Advocate advocate = db.Query<Advocate>().Single(a => a.AdvocateId == id);
           return View(advocate);
       }
       catch(InvalidOperationException ex)
       {
          //handle the case where no entity matches the supplied id (return status code 404?), or
          //there are no Advocates at all (redirect to a create page?), or
          //more than one entity matches (return status code 500)
       }
    }
