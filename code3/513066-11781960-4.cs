    [HttpPost]
    public ActionResult Delete(int id)
    {
      try
      {
         //delete the Item from the DB using the id
         // and return Deleted as the status value in JSON
         return Json(new { Status : "Deleted"});
      }
      catch(Exception eX)
      {
         //log exception
         return Json(new { Status : "Error"});
       }
    
    }
