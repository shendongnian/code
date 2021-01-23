    public ActionResult Action1 {
     TempData["shortMessage"] = "MyMessage";
     return RedirectToAction("Action2");
    }
    
    public ActionResult Action2 {
     //now I can populate my ViewBag (if I want to) with the TempData["shortMessage"] content
      ViewBag.Message = TempData["shortMessage"].ToString();
      return View();
    }
