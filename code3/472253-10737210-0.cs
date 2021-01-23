    [HttpPost]
    public ActionResult Upload()
    {
        var length = Request.ContentLength;
        var bytes = new byte[length];
    
        if (Request.Files != null)
        {
            if (Request.Files.Count > 0)
            {
                var successJson1 = new { success = true };
                return Json(successJson1);
            }
        }
    
        return Json(failJson1);
    }
