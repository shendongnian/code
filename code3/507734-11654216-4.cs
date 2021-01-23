    [AcceptVerbs(HttpVerbs.Post)] 
    public ActionResult Delete(int id)
    {
        // call your code to delete the item here
        return Json(new { resultCode = "success" });
    }
