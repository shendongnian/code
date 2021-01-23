    [HttpPost]
    public JsonResult SaveMainEventDetails(..)
    {
      if(ModelState.IsValid)
      {
        .. save to database
    
        return Json(new{ success = true });
      }
       
      var errorDict =  ModelState..
      return Json(new { success = false, errors = errorDict });
    }
