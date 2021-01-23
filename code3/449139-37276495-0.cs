    ActionResult SubmitUser()
    {
        ViewBag.Msg =TempData["Msg"];
    
        return view();
    }
    
    [HtttpPost]
    ActionResult SubmitUser()
    {
        TempData["Msg"] ="Submitted Successfully"];
    
        return view();
    }
